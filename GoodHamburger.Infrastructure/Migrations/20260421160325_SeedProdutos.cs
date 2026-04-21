using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoodHamburger.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "Category", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Pão, carne, queijo, alface, tomate e molho especial.", "X Burger", 5m, null },
                    { 2, true, 1, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Pão, carne, ovo, alface, tomate e maionese.", "X Egg", 4.50m, null },
                    { 3, true, 1, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Pão integral, carne, bacon, alface e tomate.", "X Bacon", 7m, null },
                    { 4, true, 2, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Porção de batatas fritas crocantes.", "Batata Frita", 2m, null },
                    { 5, true, 2, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Lata de refrigerante gelado.", "Refrigerante", 2.50m, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
