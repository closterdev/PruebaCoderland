using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarBrand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "CarBrand",
                columns: new[] { "Id", "BrandId", "Description", "Name", "State" },
                values: new object[,]
                {
                    { 1, new Guid("848e5f39-22c7-47d4-b1a7-ea53fe06cbae"), "Es un fabricante de automóviles y camiones con sede en Detroit, Míchigan, Estados Unidos, como una división de General Motors.", "Chevrolet", true },
                    { 2, new Guid("655a0bec-4a5e-49cf-a10f-660b92219438"), "Es una firma de origen japonés fundada en 1920 y con sede en la ciudad de Hiroshima.", "Mazda", true },
                    { 3, new Guid("12b8c32f-afe4-44c8-9f21-ccf19febb7a9"), "Es una empresa multinacional fabricante de automóviles de origen estadounidense.", "Ford", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarBrand");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
