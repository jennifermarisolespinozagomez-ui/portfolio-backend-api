using PortfolioBackend.Application.Mappings;
using PortfolioBackend.Application.Services;
using PortfolioBackend.Domain.Interfaces;
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

// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Repositorios en memoria
builder.Services.AddSingleton<IProjectRepository, InMemoryProjectRepository>();
builder.Services.AddSingleton<ITechnologyRepository, InMemoryTechnologyRepository>();
builder.Services.AddSingleton<IExperienceRepository, InMemoryExperienceRepository>();

// Servicios
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITechnologyService, TechnologyService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5173",
                "https://portfolio-frontend-iz7fstjlp.vercel.app",
                "https://portfolio-frontend-weld-beta.vercel.app",
                "https://jenniffer-espinoza.vercel.app"
              )
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
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
