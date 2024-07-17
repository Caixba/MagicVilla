using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class CorrigiendoPKVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_villas",
                table: "villas");

            migrationBuilder.RenameTable(
                name: "villas",
                newName: "Villas");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Villas",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Villas",
                table: "Villas",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 17, 16, 55, 9, 108, DateTimeKind.Local).AddTicks(9621), new DateTime(2024, 7, 17, 16, 55, 9, 108, DateTimeKind.Local).AddTicks(9605) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 17, 16, 55, 9, 108, DateTimeKind.Local).AddTicks(9624), new DateTime(2024, 7, 17, 16, 55, 9, 108, DateTimeKind.Local).AddTicks(9624) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 17, 16, 55, 9, 108, DateTimeKind.Local).AddTicks(9627), new DateTime(2024, 7, 17, 16, 55, 9, 108, DateTimeKind.Local).AddTicks(9627) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Villas",
                table: "Villas");

            migrationBuilder.RenameTable(
                name: "Villas",
                newName: "villas");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "villas",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_villas",
                table: "villas",
                column: "id");

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 17, 16, 36, 20, 995, DateTimeKind.Local).AddTicks(6128), new DateTime(2024, 7, 17, 16, 36, 20, 995, DateTimeKind.Local).AddTicks(6106) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 17, 16, 36, 20, 995, DateTimeKind.Local).AddTicks(6138), new DateTime(2024, 7, 17, 16, 36, 20, 995, DateTimeKind.Local).AddTicks(6137) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 7, 17, 16, 36, 20, 995, DateTimeKind.Local).AddTicks(6145), new DateTime(2024, 7, 17, 16, 36, 20, 995, DateTimeKind.Local).AddTicks(6143) });
        }
    }
}
