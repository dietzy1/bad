using Microsoft.EntityFrameworkCore;
using Bakery.Models;
using Bakery.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

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

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();

// Attempt to connect to the database and log the result
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BakeryContext>();
    try
    {
        if (dbContext.Database.CanConnect())
        {
            logger.LogInformation("Successfully connected to the database! Migrating...");
            dbContext.Database.Migrate();
        }
        else
        {
            logger.LogWarning("Could not connect to the database.");
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

app.MapControllers();
app.Run();
