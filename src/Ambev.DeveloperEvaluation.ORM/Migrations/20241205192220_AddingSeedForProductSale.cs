using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class AddingSeedForProductSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Product",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Sale",
                columns: new[] { "Id", "Branch", "Number", "SaleDate", "TotalSaleAmount" },
                values: new object[,]
                {
                    { new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08"), "Nordeste", 100, new DateOnly(2024, 12, 5), 1255.49m },
                    { new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635"), "Norte", 201, new DateOnly(2024, 10, 15), 355.15m },
                    { new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038"), "Sudeste", 300, new DateOnly(2024, 9, 20), 898.37m }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name", "Price", "Quantity", "SaleId" },
                values: new object[,]
                {
                    { new Guid("1df6f7aa-7f21-437d-a933-64040078dfe3"), "Smartphone Samsumg Galaxy A15", 2499.99m, 50, new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635") },
                    { new Guid("75bc82b9-7463-432b-9515-ad7aa58e53b1"), "PlayStation 5 Digital Edition", 4999m, 50, new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038") },
                    { new Guid("8557301e-2b65-4318-9f14-be00bffb0004"), "Joystick Dual Shock USB", 129.99m, 2, new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08") },
                    { new Guid("bcd13823-964d-498f-8f78-980aba3ee56f"), "Fone de ouvido bluetooth", 150m, 10, new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("1df6f7aa-7f21-437d-a933-64040078dfe3"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("75bc82b9-7463-432b-9515-ad7aa58e53b1"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("8557301e-2b65-4318-9f14-be00bffb0004"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("bcd13823-964d-498f-8f78-980aba3ee56f"));

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08"));

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635"));

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Product");
        }
    }
}
