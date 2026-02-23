using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Period = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Project = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Technologies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    HoursInvested = table.Column<int>(type: "int", nullable: false),
                    GithubUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    YearsOfExperience = table.Column<decimal>(type: "decimal(3,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTechnologies",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TechnologyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTechnologies", x => new { x.ProjectId, x.TechnologyId });
                    table.ForeignKey(
                        name: "FK_ProjectTechnologies_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTechnologies_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "Company", "CreatedAt", "EndDate", "IsActive", "Period", "Project", "Role", "StartDate", "Technologies", "Usage" },
                values: new object[,]
                {
                    { 1, "N5 Now", new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "20 Feb 2025 - Actualidad", "Sistema de Gestión de Formularios", "Desarrolladora de Software", new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "[\"React\",\"TypeScript\",\"C# .NET\",\"MongoDB\",\"PostgreSQL\",\"Elsa Workflows\",\"SQL\"]", "Desarrollo de interfaces y tablas CRUD + creación de controladores, repositorios y migraciones SQL para base de datos + pruebas unitarias e integración" },
                    { 2, "Aeroméxico", new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "20 Feb 2025 - Actualidad", "Sistema de Pagos Móviles Aeroméxico", "Tester", new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "[\"Java 17\",\"Spring Boot\",\"MongoDB\",\"Sabre GDS\",\"AWS SQS\",\"WebSocket\",\"Postman\"]", "Pruebas funcionales e integración de sistema de pagos móviles + validación de flujos de pago, emisión de tickets y reembolsos + verificación de endpoints REST y notificaciones WebSocket" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAt", "Description", "GithubUrl", "HoursInvested", "ImageUrl", "Semester", "Title", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sistema web Full Stack para gestión de recursos comunitarios", "https://github.com/usuario/micomunidad", 150, "/images/proyecto-gestion-recursos.png", 7, "MiComunidad - Gestión de Recursos", "Web" },
                    { 2, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dashboard de Business Intelligence con visualizaciones interactivas", "https://github.com/usuario/dashboard-bi", 100, "/images/dashboard-bi.png", 7, "Dashboard BI", "Web" },
                    { 3, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sistema de pagos móviles para aerolínea", "https://github.com/usuario/pagos-aeromexico", 160, "/images/pagos-aeromexico.png", 8, "Pagos Móviles Aeroméxico", "Web" },
                    { 4, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "API REST para plataforma de comercio electrónico", "https://github.com/usuario/api-ecommerce", 90, "/images/api-ecommerce.png", 5, "API E-commerce", "API" }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Category", "Name", "YearsOfExperience" },
                values: new object[,]
                {
                    { 1, "Backend", "C", 2m },
                    { 2, "Backend", "C++", 2m },
                    { 3, "Backend", "Java", 1m },
                    { 4, "Backend", "POO", 2m },
                    { 5, "Frontend", "Angular 21", 1m },
                    { 6, "Frontend", "TypeScript 5.9", 2m },
                    { 7, "Frontend", "JavaScript", 2m },
                    { 8, "Frontend", "HTML", 3m },
                    { 9, "Frontend", "CSS", 3m },
                    { 10, "Backend", "Spring Boot", 1m },
                    { 11, "Frontend", "React", 1m },
                    { 12, "Backend", "Node.js", 1m },
                    { 13, "Database", "MongoDB", 1m },
                    { 14, "Database", "PostgreSQL", 1m },
                    { 15, "Database", "SQL Server", 2m },
                    { 16, "Tools", "Git", 2m },
                    { 17, "Tools", "Docker", 1m },
                    { 18, "Backend", "ASP.NET Core", 1m },
                    { 19, "Backend", "Elsa Workflows", 0.5m },
                    { 20, "Tools", "New Relic", 0.5m },
                    { 21, "Mobile", "Android", 1m },
                    { 22, "Tools", "Postman", 2m }
                });

            migrationBuilder.InsertData(
                table: "ProjectTechnologies",
                columns: new[] { "ProjectId", "TechnologyId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 15 },
                    { 1, 18 },
                    { 2, 11 },
                    { 2, 13 },
                    { 3, 3 },
                    { 3, 10 },
                    { 3, 13 },
                    { 4, 15 },
                    { 4, 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechnologies_TechnologyId",
                table: "ProjectTechnologies",
                column: "TechnologyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "ProjectTechnologies");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Technologies");
        }
    }
}
