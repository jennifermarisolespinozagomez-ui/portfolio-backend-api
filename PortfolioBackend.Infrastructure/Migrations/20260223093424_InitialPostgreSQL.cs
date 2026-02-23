using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgreSQL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Company = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Role = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Modality = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Period = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Project = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Technologies = table.Column<string>(type: "text", nullable: false),
                    Usage = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Semester = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    HoursInvested = table.Column<int>(type: "integer", nullable: false),
                    GithubUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    YearsOfExperience = table.Column<decimal>(type: "numeric(3,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTechnologies",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    TechnologyId = table.Column<int>(type: "integer", nullable: false)
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
                columns: new[] { "Id", "Company", "CreatedAt", "EndDate", "IsActive", "Modality", "Period", "Project", "Role", "StartDate", "Technologies", "Usage" },
                values: new object[,]
                {
                    { 1, "N5 Now", new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Outsourcing", "20 Feb 2025 - Actualidad", "Sistema de Gestión de Formularios", "– Empresa de software para el sector financiero.", new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "[\"React\",\"TypeScript\",\"C# .NET\",\"MongoDB\",\"PostgreSQL\",\"Elsa Workflows\",\"SQL\"]", "Desarrollo de interfaces y tablas CRUD + creación de controladores, repositorios y migraciones SQL para base de datos + pruebas unitarias e integración" },
                    { 2, "Aeroméxico", new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Outsourcing", "20 Feb 2025 - Actualidad", "Sistema de Pagos Móviles Aeroméxico", "– Aerolínea internacional de transporte de pasajeros y carga", new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "[\"Java 17\",\"Spring Boot\",\"MongoDB\",\"Sabre GDS\",\"AWS SQS\",\"WebSocket\",\"Postman\"]", "Pruebas funcionales e integración de sistema de pagos móviles + validación de flujos de pago, emisión de tickets y reembolsos + verificación de endpoints REST y notificaciones WebSocket" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAt", "Description", "GithubUrl", "HoursInvested", "ImageUrl", "Semester", "Title", "Type" },
                values: new object[] { 1, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sistema web Full Stack para gestión de recursos comunitarios con autenticación JWT, arquitectura limpia y componentes UI modernos.", "https://github.com/usuario/micomunidad", 150, "/images/proyecto-gestion-recursos.png", 7, "MiComunidad - Gestión de Recursos", "Web" });

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
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 15 },
                    { 1, 18 }
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
