using backend.Data; // Import JobBoardContext
using backend.DataAccess;
using backend.Services;
using Microsoft.EntityFrameworkCore; // Import EF Core
using Pomelo.EntityFrameworkCore.MySql; // MySQL provider

var builder = WebApplication.CreateBuilder(args);

// Ajout controller
builder.Services.AddControllers();

// Ajout DAO et Services
builder.Services.AddScoped<ApplicationsDAO>();
builder.Services.AddScoped<ApplicationsService>();

builder.Services.AddScoped<CompaniesDAO>();
builder.Services.AddScoped<CompaniesService>();

builder.Services.AddScoped<ExperiencesDAO>();
builder.Services.AddScoped<ExperiencesService>();

builder.Services.AddScoped<FormationsDAO>();
builder.Services.AddScoped<FormationsService>();

builder.Services.AddScoped<JobOfferDAO>();
builder.Services.AddScoped<JobOfferService>();

builder.Services.AddScoped<UserCompetenciesDAO>();
builder.Services.AddScoped<UserCompService>();

builder.Services.AddScoped<UserDAO>();
builder.Services.AddScoped<UsersService>();

// Configure la base de donnée : ajout JobBoardContext et ce que j'ai mis dans appsettings.json
builder.Services.AddDbContext<JobBoardContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("SqlConnection"),
        new MySqlServerVersion(new Version(8, 0, 32))
    ));



var app = builder.Build();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Mappe les routes des contrôleurs

app.MapGet("/", () => "API is running ! ");

app.Run();

