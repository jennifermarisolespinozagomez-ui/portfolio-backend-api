using Microsoft.EntityFrameworkCore;
using PortfolioBackend.Application.Mappings;
using PortfolioBackend.Application.Services;
using PortfolioBackend.Domain.Interfaces;
using PortfolioBackend.Infrastructure.Data;
using PortfolioBackend.Infrastructure.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Entity Framework Core
var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
if (string.IsNullOrEmpty(connectionString))
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}
else
{
    // Convertir formato Render a formato Npgsql
    // Render: postgresql://user:pass@host:port/dbname
    // Npgsql: Host=host;Port=port;Database=dbname;Username=user;Password=pass;SSL Mode=Require;Trust Server Certificate=true
    var databaseUri = new Uri(connectionString);
    connectionString = $"Host={databaseUri.Host};Port={databaseUri.Port};Database={databaseUri.AbsolutePath.TrimStart('/')};Username={databaseUri.UserInfo.Split(':')[0]};Password={databaseUri.UserInfo.Split(':')[1]};SSL Mode=Require;Trust Server Certificate=true";
}
builder.Services.AddDbContext<PortfolioDbContext>(options =>
    options.UseNpgsql(connectionString));

// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Repositorios
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ITechnologyRepository, TechnologyRepository>();
builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();

// Servicios
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITechnologyService, TechnologyService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();

// CORS
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() 
    ?? new[] { "http://localhost:5173" };

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Caché en memoria
builder.Services.AddMemoryCache();

// Compresión de respuestas
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});

var app = builder.Build();

// Migraciones deshabilitadas - las tablas ya están creadas
// if (app.Environment.IsProduction())
// {
//     try
//     {
//         using var scope = app.Services.CreateScope();
//         var dbContext = scope.ServiceProvider.GetRequiredService<PortfolioDbContext>();
//         dbContext.Database.Migrate();
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine($"Error aplicando migraciones: {ex.Message}");
//     }
// }

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseResponseCompression();
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

app.Run();
