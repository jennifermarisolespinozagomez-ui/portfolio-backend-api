using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedDataCorrect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectTechnologies",
                keyColumns: new[] { "ProjectId", "TechnologyId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnologies",
                keyColumns: new[] { "ProjectId", "TechnologyId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnologies",
                keyColumns: new[] { "ProjectId", "TechnologyId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnologies",
                keyColumns: new[] { "ProjectId", "TechnologyId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnologies",
                keyColumns: new[] { "ProjectId", "TechnologyId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnologies",
                keyColumns: new[] { "ProjectId", "TechnologyId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnologies",
                keyColumns: new[] { "ProjectId", "TechnologyId" },
                keyValues: new object[] { 4, 18 });

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "ProjectTechnologies",
                columns: new[] { "ProjectId", "TechnologyId" },
                values: new object[,]
                {
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Sistema web Full Stack para gestión de recursos comunitarios con autenticación JWT, arquitectura limpia y componentes UI modernos.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectTechnologies",
                keyColumns: new[] { "ProjectId", "TechnologyId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnologies",
                keyColumns: new[] { "ProjectId", "TechnologyId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "ProjectTechnologies",
                keyColumns: new[] { "ProjectId", "TechnologyId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Sistema web Full Stack para gestión de recursos comunitarios");

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAt", "Description", "GithubUrl", "HoursInvested", "ImageUrl", "Semester", "Title", "Type" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dashboard de Business Intelligence con visualizaciones interactivas", "https://github.com/usuario/dashboard-bi", 100, "/images/dashboard-bi.png", 7, "Dashboard BI", "Web" },
                    { 3, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sistema de pagos móviles para aerolínea", "https://github.com/usuario/pagos-aeromexico", 160, "/images/pagos-aeromexico.png", 8, "Pagos Móviles Aeroméxico", "Web" },
                    { 4, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "API REST para plataforma de comercio electrónico", "https://github.com/usuario/api-ecommerce", 90, "/images/api-ecommerce.png", 5, "API E-commerce", "API" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTechnologies",
                columns: new[] { "ProjectId", "TechnologyId" },
                values: new object[,]
                {
                    { 2, 11 },
                    { 2, 13 },
                    { 3, 3 },
                    { 3, 10 },
                    { 3, 13 },
                    { 4, 15 },
                    { 4, 18 }
                });
        }
    }
}
