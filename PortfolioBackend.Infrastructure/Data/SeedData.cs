using Microsoft.EntityFrameworkCore;
using PortfolioBackend.Domain.Entities;

namespace PortfolioBackend.Infrastructure.Data;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var technologies = new[]
        {
            new Technology { Id = 1, Name = "C", Category = "Backend", YearsOfExperience = 2m },
            new Technology { Id = 2, Name = "C++", Category = "Backend", YearsOfExperience = 2m },
            new Technology { Id = 3, Name = "Java", Category = "Backend", YearsOfExperience = 1m },
            new Technology { Id = 4, Name = "POO", Category = "Backend", YearsOfExperience = 2m },
            new Technology { Id = 5, Name = "Angular 21", Category = "Frontend", YearsOfExperience = 1m },
            new Technology { Id = 6, Name = "TypeScript 5.9", Category = "Frontend", YearsOfExperience = 2m },
            new Technology { Id = 7, Name = "JavaScript", Category = "Frontend", YearsOfExperience = 2m },
            new Technology { Id = 8, Name = "HTML", Category = "Frontend", YearsOfExperience = 3m },
            new Technology { Id = 9, Name = "CSS", Category = "Frontend", YearsOfExperience = 3m },
            new Technology { Id = 10, Name = "Spring Boot", Category = "Backend", YearsOfExperience = 1m },
            new Technology { Id = 11, Name = "React", Category = "Frontend", YearsOfExperience = 1m },
            new Technology { Id = 12, Name = "Node.js", Category = "Backend", YearsOfExperience = 1m },
            new Technology { Id = 13, Name = "MongoDB", Category = "Database", YearsOfExperience = 1m },
            new Technology { Id = 14, Name = "PostgreSQL", Category = "Database", YearsOfExperience = 1m },
            new Technology { Id = 15, Name = "SQL Server", Category = "Database", YearsOfExperience = 2m },
            new Technology { Id = 16, Name = "Git", Category = "Tools", YearsOfExperience = 2m },
            new Technology { Id = 17, Name = "Docker", Category = "Tools", YearsOfExperience = 1m },
            new Technology { Id = 18, Name = "ASP.NET Core", Category = "Backend", YearsOfExperience = 1m },
            new Technology { Id = 19, Name = "Elsa Workflows", Category = "Backend", YearsOfExperience = 0.5m },
            new Technology { Id = 20, Name = "New Relic", Category = "Tools", YearsOfExperience = 0.5m },
            new Technology { Id = 21, Name = "Android", Category = "Mobile", YearsOfExperience = 1m },
            new Technology { Id = 22, Name = "Postman", Category = "Tools", YearsOfExperience = 2m }
        };
        
        modelBuilder.Entity<Technology>().HasData(technologies);

        var projects = new[]
        {
            new Project 
            { 
                Id = 1, 
                Title = "MiComunidad - Gestión de Recursos", 
                Description = "Sistema web Full Stack para gestión de recursos comunitarios con autenticación JWT, arquitectura limpia y componentes UI modernos.",
                Semester = 7,
                Type = "Web",
                ImageUrl = "/images/proyecto-gestion-recursos.png",
                HoursInvested = 150,
                GithubUrl = "https://github.com/usuario/micomunidad",
                CreatedAt = new DateTime(2025, 2, 1)
            }
        };
        
        modelBuilder.Entity<Project>().HasData(projects);

        var projectTechnologies = new[]
        {
            new ProjectTechnology { ProjectId = 1, TechnologyId = 5 },
            new ProjectTechnology { ProjectId = 1, TechnologyId = 6 },
            new ProjectTechnology { ProjectId = 1, TechnologyId = 7 },
            new ProjectTechnology { ProjectId = 1, TechnologyId = 8 },
            new ProjectTechnology { ProjectId = 1, TechnologyId = 9 },
            new ProjectTechnology { ProjectId = 1, TechnologyId = 18 },
            new ProjectTechnology { ProjectId = 1, TechnologyId = 15 }
        };
        
        modelBuilder.Entity<ProjectTechnology>().HasData(projectTechnologies);

        var experiences = new[]
        {
            new Experience
            {
                Id = 1,
                Company = "N5 Now",
                Role = "– Empresa de software para el sector financiero.",
                Modality = "Outsourcing",
                Period = "20 Feb 2025 - Actualidad",
                Project = "Sistema de Gestión de Formularios",
                Technologies = "[\"React\",\"TypeScript\",\"C# .NET\",\"MongoDB\",\"PostgreSQL\",\"Elsa Workflows\",\"SQL\"]",
                Usage = "Desarrollo de interfaces y tablas CRUD + creación de controladores, repositorios y migraciones SQL para base de datos + pruebas unitarias e integración",
                IsActive = true,
                StartDate = new DateTime(2025, 2, 20),
                EndDate = null,
                CreatedAt = new DateTime(2025, 2, 20)
            },
            new Experience
            {
                Id = 2,
                Company = "Aeroméxico",
                Role = "– Aerolínea internacional de transporte de pasajeros y carga",
                Modality = "Outsourcing",
                Period = "20 Feb 2025 - Actualidad",
                Project = "Sistema de Pagos Móviles Aeroméxico",
                Technologies = "[\"Java 17\",\"Spring Boot\",\"MongoDB\",\"Sabre GDS\",\"AWS SQS\",\"WebSocket\",\"Postman\"]",
                Usage = "Pruebas funcionales e integración de sistema de pagos móviles + validación de flujos de pago, emisión de tickets y reembolsos + verificación de endpoints REST y notificaciones WebSocket",
                IsActive = true,
                StartDate = new DateTime(2025, 2, 20),
                EndDate = null,
                CreatedAt = new DateTime(2025, 2, 20)
            }
        };
        
        modelBuilder.Entity<Experience>().HasData(experiences);
    }
}
