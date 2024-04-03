using Microsoft.EntityFrameworkCore;
using Bakery.Models;

var builder = WebApplication.CreateBuilder(args);

//Controller layer injected by magic or what the fuck?
builder.Services.AddControllers();
builder.Services.AddDbContext<BakeryContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Data layer


//Do some fuckery c#??

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
            logger.LogInformation("Successfully connected to the database.");
        }
        else
        {
            logger.LogWarning("Could not connect to the database.");
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while connecting to the database.");
    }
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/hello", () =>
{
    var hello = "hello";
    return hello;

}
).WithName("GetHello").WithOpenApi();

app.MapControllers();

app.Run();

