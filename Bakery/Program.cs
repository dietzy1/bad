using Microsoft.EntityFrameworkCore;
using Bakery.Models;
using Bakery.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<BakeryContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Data layer
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<BakingGoodRepository>();
builder.Services.AddScoped<BatchRepository>();
builder.Services.AddScoped<IngredientRepository>();

builder.Services.AddIdentity<ApiUser, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 4;
    }
    )
    .AddEntityFrameworkStores<BakeryContext>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });



var app = builder.Build();

//var logger = app.Services.GetRequiredService<ILogger<Program>>();
// Configure Serilog
//FIXME: 
var logger = new LoggerConfiguration()
    .WriteTo.MongoDB(cfg =>
    {
        var mongoDbSettings = new MongoClientSettings
        {
            UseTls = true,
            AllowInsecureTls = true,
            Credential = MongoCredential.CreateCredential("databaseName", "username", "password"),
            Server = new MongoServerAddress("127.0.0.1")
        };

        var mongoDbInstance = new MongoClient(mongoDbSettings).GetDatabase("serilog");
        cfg.SetMongoDatabase(mongoDbInstance);
        cfg.SetRollingInterval(RollingInterval.Month);
    })
    .CreateLogger();




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
        logger.LogError(ex, "An error occurred while connecting or migrating the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();
app.Run();
