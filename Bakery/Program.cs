using Microsoft.EntityFrameworkCore;
using Bakery.Models;
using Bakery.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Serilog;
using Bakery.Seed;
using Amazon.Auth.AccessControlPolicy;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<BakeryContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please insert JWT with Bearer into field",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });

//Data layer
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<BakingGoodRepository>();
builder.Services.AddScoped<BatchRepository>();
builder.Services.AddScoped<IngredientRepository>();

//What the actual fuck is this? 🤯
builder.Services.AddScoped<LogRepository>(provider =>
        {
            var connectionString = builder.Configuration.GetConnectionString("MongoDb");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("MongoDb connection string is not configured.");
            }
            return new LogRepository(connectionString);

        });



//Ship logs to mongoDB by using magic configuration files :)
builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddIdentity<ApiUser, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 4;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
    }
    )
    .AddEntityFrameworkStores<BakeryContext>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"] ?? throw new Exception("JWT:SigningKey not found")))
        };
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("Admin", policy => policy.RequireClaim("Rank", "4"))
    .AddPolicy("Manager", policy => policy.RequireClaim("Rank", "4", "3"))
    .AddPolicy("Baker", policy => policy.RequireClaim("Rank", "4", "3", "2"))
    .AddPolicy("Driver", Policy => Policy.RequireClaim("Rank", "4", "3", "1"));



//builder.Host.UseSerilog((ctx, config) => config.ReadFrom.Configuration(ctx.Configuration));

var app = builder.Build();

var log = app.Services.GetRequiredService<ILogger<Program>>();

// Attempt to connect to the database and log the result
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BakeryContext>();
    try
    {
        if (dbContext.Database.CanConnect())
        {

            dbContext.Database.Migrate();
        }

    }
    catch (Exception ex)
    {
        log.LogError(ex, "An error occurred while connecting or migrating the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApiUser>>() ?? throw new Exception("UserManager is null");
    SeedAuthorization.SeedAdmin(userManager);
    SeedAuthorization.SeedManager(userManager);
    SeedAuthorization.SeedBaker(userManager);
    SeedAuthorization.SeedDriver(userManager);
}

app.Run();
