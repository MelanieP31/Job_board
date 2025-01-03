using backend.Configuration; // Import JobBoardContext
using backend.Services;
using Microsoft.EntityFrameworkCore; // Import EF Core
using Pomelo.EntityFrameworkCore.MySql; // MySQL provider

var builder = WebApplication.CreateBuilder(args);

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Ajout controller
builder.Services.AddControllers();

// Ajout DAO et Services
builder.Services.AddScoped<ApplicationsService>();
builder.Services.AddScoped<CompaniesService>();
builder.Services.AddScoped<ExperiencesService>();
builder.Services.AddScoped<FormationsService>();
builder.Services.AddScoped<JobOfferService>();
builder.Services.AddScoped<UserCompService>();
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

