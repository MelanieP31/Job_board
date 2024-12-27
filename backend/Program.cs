using backend.Data; // Import JobBoardContext
using backend.DataAccess;
using backend.Services;
using Microsoft.EntityFrameworkCore; // Import EF Core
using Pomelo.EntityFrameworkCore.MySql; // MySQL provider

var builder = WebApplication.CreateBuilder(args);

// Ajout services
builder.Services.AddControllers();

builder.Services.AddScoped<UserDAO>();
builder.Services.AddScoped<UsersService>();

// Configure la base de donnée : ajout JobBoardContext et ce que j'ai mis dans appsettings.json
builder.Services.AddDbContext<JobBoardContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 32))
    ));



var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Mappe les routes des contrôleurs

app.Run();

