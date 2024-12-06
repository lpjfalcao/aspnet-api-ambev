using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class CreatingTablesSalesAndProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    SaleDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalSaleAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Branch = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sale",
                columns: new[] { "Id", "Branch", "Number", "SaleDate", "Status", "TotalSaleAmount" },
                values: new object[,]
                {
                    { new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08"), "Nordeste", 100, new DateOnly(2024, 12, 5), 1, 1255.49m },
                    { new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635"), "Norte", 201, new DateOnly(2024, 10, 15), 1, 355.15m },
                    { new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038"), "Sudeste", 300, new DateOnly(2024, 9, 20), 1, 898.37m }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name", "Price", "Quantity", "SaleId" },
                values: new object[,]
                {
                    { new Guid("1df6f7aa-7f21-437d-a933-64040078dfe3"), "Smartphone Samsumg Galaxy A15", 2499.99m, 50, new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08") },
                    { new Guid("1f7b9089-cdd7-4ac7-8805-58ee3e3892f3"), "Notebook Dell Inspiron 1234", 3299.99m, 1, new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635") },
                    { new Guid("6887a1dc-f10b-44f4-975d-41e5422521c6"), "The Legend of Zelda: Ocarina of Time Last Edition", 155.99m, 1, new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038") },
                    { new Guid("75bc82b9-7463-432b-9515-ad7aa58e53b1"), "PlayStation 5 Digital Edition", 4999m, 50, new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08") },
                    { new Guid("77407f66-0e7f-4b0f-9b50-dd26aa5ba504"), "Warcraft III: Ultimate Edition", 265.34m, 20, new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635") },
                    { new Guid("8557301e-2b65-4318-9f14-be00bffb0004"), "Joystick Dual Shock USB", 129.99m, 2, new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635") },
                    { new Guid("bcd13823-964d-498f-8f78-980aba3ee56f"), "Fone de ouvido bluetooth", 150m, 10, new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08") },
                    { new Guid("e7d93403-7a58-4755-9e4e-e991782a3267"), "Smart Watch Apple", 1500m, 100, new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038") },
                    { new Guid("f50cf636-63a3-49af-92df-9bf274b93733"), "Ratchet & Clank", 299.99m, 5, new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_SaleId",
                table: "Product",
                column: "SaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");           

            migrationBuilder.DropTable(
                name: "Sale");
        }
    }
}
