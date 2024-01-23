using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_Api.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablavilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "villa",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacio", "FechaCreacion", "ImagenUrl", "Metroscuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Detalle de la Villa...", new DateTime(2024, 1, 22, 21, 49, 21, 346, DateTimeKind.Local).AddTicks(8249), new DateTime(2024, 1, 22, 21, 49, 21, 346, DateTimeKind.Local).AddTicks(8233), "", 50, "Villa Real", 5, 200.0 },
                    { 2, "", "Detalle de la Villa...", new DateTime(2024, 1, 22, 21, 49, 21, 346, DateTimeKind.Local).AddTicks(8255), new DateTime(2024, 1, 22, 21, 49, 21, 346, DateTimeKind.Local).AddTicks(8254), "", 40, "Primium vitas  a la Piscina", 4, 150.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "villa",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "villa",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
