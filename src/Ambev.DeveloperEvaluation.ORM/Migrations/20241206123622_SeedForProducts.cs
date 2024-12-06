using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class SeedForProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name", "Price", "Quantity", "SaleId" },
                values: new object[,]
                {
                    { new Guid("1f7b9089-cdd7-4ac7-8805-58ee3e3892f3"), "Notebook Dell Inspiron 1234", 3299.99m, 1, new Guid("0ae77512-d9f2-4fc1-b894-d6c97285702d") },
                    { new Guid("6887a1dc-f10b-44f4-975d-41e5422521c6"), "The Legend of Zelda: Ocarina of Time Last Edition", 155.99m, 1, new Guid("45426998-bfc5-405e-afbe-1068e9b567ef") },
                    { new Guid("77407f66-0e7f-4b0f-9b50-dd26aa5ba504"), "Warcraft III: Ultimate Edition", 265.34m, 20, new Guid("0ae77512-d9f2-4fc1-b894-d6c97285702d") },
                    { new Guid("e7d93403-7a58-4755-9e4e-e991782a3267"), "Smart Watch Apple", 1500m, 100, new Guid("45426998-bfc5-405e-afbe-1068e9b567ef") },
                    { new Guid("f50cf636-63a3-49af-92df-9bf274b93733"), "Ratchet & Clank", 299.99m, 5, new Guid("0ae77512-d9f2-4fc1-b894-d6c97285702d") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("1f7b9089-cdd7-4ac7-8805-58ee3e3892f3"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("6887a1dc-f10b-44f4-975d-41e5422521c6"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("77407f66-0e7f-4b0f-9b50-dd26aa5ba504"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("e7d93403-7a58-4755-9e4e-e991782a3267"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f50cf636-63a3-49af-92df-9bf274b93733"));
        }
    }
}
