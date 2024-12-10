using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingTotalAmounOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08"),
                column: "TotalAmount",
                value: 199.98m);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635"),
                column: "TotalAmount",
                value: 99.99m);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038"),
                column: "TotalAmount",
                value: 2099.79m);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: new Guid("a961d01e-ba3c-44ad-8bf0-5a552fd16df4"),
                column: "Quantity",
                value: 21);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("4c032dec-2fbf-472b-8a66-9b332b289e08"),
                column: "TotalAmount",
                value: 1255.49m);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("afc53abe-c973-4dda-bae4-8e7a12ec4635"),
                column: "TotalAmount",
                value: 1255.49m);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("db08cc4d-a1e5-4459-bf64-64395a1bb038"),
                column: "TotalAmount",
                value: 1255.49m);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: new Guid("a961d01e-ba3c-44ad-8bf0-5a552fd16df4"),
                column: "Quantity",
                value: 1);
        }
    }
}
