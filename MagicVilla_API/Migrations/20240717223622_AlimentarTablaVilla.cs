using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablaVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "villas",
                columns: new[] { "id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Villa de lujo", new DateTime(2024, 7, 17, 16, 36, 20, 995, DateTimeKind.Local).AddTicks(6128), new DateTime(2024, 7, 17, 16, 36, 20, 995, DateTimeKind.Local).AddTicks(6106), "", 200, "Villa 1", 4, 1000.0 },
                    { 2, "", "Villa de lujo2", new DateTime(2024, 7, 17, 16, 36, 20, 995, DateTimeKind.Local).AddTicks(6138), new DateTime(2024, 7, 17, 16, 36, 20, 995, DateTimeKind.Local).AddTicks(6137), "", 300, "Villa 2", 5, 2000.0 },
                    { 3, "", "Villa de luj3o", new DateTime(2024, 7, 17, 16, 36, 20, 995, DateTimeKind.Local).AddTicks(6145), new DateTime(2024, 7, 17, 16, 36, 20, 995, DateTimeKind.Local).AddTicks(6143), "", 400, "Villa 3", 6, 3000.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
