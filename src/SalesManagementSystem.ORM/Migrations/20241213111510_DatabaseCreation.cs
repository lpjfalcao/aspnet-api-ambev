using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesManagementSystem.ORM.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsCancelled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("654846d5-a5b3-47a0-a503-741accfd0f6d"), "Nordeste do Brasil", "Nordeste" },
                    { new Guid("780fc7c0-b86e-4ee8-8bae-518ca75ef200"), "Norte do Brasil", "Norte" },
                    { new Guid("bc50086e-21be-4188-b4b3-10cc63927ba3"), "Sudeste do Brasil", "Sudeste" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("7bfc1fee-ac07-4326-94a0-95f2c331e260"), "morpheus@email.com", "Morpheus" },
                    { new Guid("91e27f09-c405-4a09-8450-4c016fa38430"), "trinity@email.com", "Trinity" },
                    { new Guid("a35ee010-bca0-42d2-a662-a362475255ed"), "neo@email.com", "Neo" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1df6f7aa-7f21-437d-a933-64040078dfe3"), "Smartphone de última geração", "Smartphone Samsumg Galaxy A15" },
                    { new Guid("6887a1dc-f10b-44f4-975d-41e5422521c6"), "Jogo clássico para Nintendo 64", "The Legend of Zelda: Ocarina of Time Last Edition" },
                    { new Guid("75bc82b9-7463-432b-9515-ad7aa58e53b1"), "Videogame", "PlayStation 5 Digital Edition" },
                    { new Guid("77407f66-0e7f-4b0f-9b50-dd26aa5ba504"), "Jogo clássico da Blizzard Entertainment de estratégia em 3D", "Warcraft III: Ultimate Edition" },
                    { new Guid("8557301e-2b65-4318-9f14-be00bffb0004"), "Controle de videogame para o PC", "Joystick Dual Shock USB" },
                    { new Guid("bcd13823-964d-498f-8f78-980aba3ee56f"), "Fontes de ouvido", "Fone de ouvido bluetooth" },
                    { new Guid("e7d93403-7a58-4755-9e4e-e991782a3267"), "Dispositivo eletrônico", "Smart Watch Apple" },
                    { new Guid("f50cf636-63a3-49af-92df-9bf274b93733"), "Jogo da Insominiac game de aventura em terceira pessoa", "Ratchet & Clank" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "BranchId", "CustomerId", "IsCancelled", "OrderDate", "TotalAmount" },
                values: new object[,]
                {
                    { new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08"), new Guid("654846d5-a5b3-47a0-a503-741accfd0f6d"), new Guid("a35ee010-bca0-42d2-a662-a362475255ed"), false, new DateOnly(2024, 12, 5), 199.98m },
                    { new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635"), new Guid("bc50086e-21be-4188-b4b3-10cc63927ba3"), new Guid("7bfc1fee-ac07-4326-94a0-95f2c331e260"), false, new DateOnly(2024, 12, 5), 99.99m },
                    { new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038"), new Guid("780fc7c0-b86e-4ee8-8bae-518ca75ef200"), new Guid("91e27f09-c405-4a09-8450-4c016fa38430"), false, new DateOnly(2024, 12, 5), 2099.79m }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "Discount", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("13e46eaf-df54-4d87-adc5-4f3274bab0eb"), 0m, new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08"), new Guid("bcd13823-964d-498f-8f78-980aba3ee56f"), 1, 99.99m },
                    { new Guid("5554a5b9-59fc-4b39-b2d2-eb4e0aea2f75"), 0m, new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635"), new Guid("1df6f7aa-7f21-437d-a933-64040078dfe3"), 1, 99.99m },
                    { new Guid("8a753aa0-c60a-403e-b3c5-6ab0bd728cb0"), 0m, new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08"), new Guid("75bc82b9-7463-432b-9515-ad7aa58e53b1"), 1, 99.99m },
                    { new Guid("a961d01e-ba3c-44ad-8bf0-5a552fd16df4"), 0m, new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038"), new Guid("8557301e-2b65-4318-9f14-be00bffb0004"), 21, 99.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_BranchId",
                table: "Order",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
