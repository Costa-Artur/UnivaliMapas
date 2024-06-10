using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnivaliMapas.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoSeed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Aulas",
                keyColumn: "AulaId",
                keyValue: 1,
                column: "Data",
                value: new DateTime(2024, 6, 10, 14, 50, 25, 253, DateTimeKind.Utc).AddTicks(4947));

            migrationBuilder.UpdateData(
                table: "Aulas",
                keyColumn: "AulaId",
                keyValue: 2,
                column: "Data",
                value: new DateTime(2024, 6, 11, 14, 50, 25, 253, DateTimeKind.Utc).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "Aulas",
                keyColumn: "AulaId",
                keyValue: 3,
                column: "Data",
                value: new DateTime(2024, 6, 12, 14, 50, 25, 253, DateTimeKind.Utc).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "Aulas",
                keyColumn: "AulaId",
                keyValue: 4,
                columns: new[] { "Data", "SalaId" },
                values: new object[] { new DateTime(2024, 6, 13, 14, 50, 25, 253, DateTimeKind.Utc).AddTicks(4957), 6 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Aulas",
                keyColumn: "AulaId",
                keyValue: 1,
                column: "Data",
                value: new DateTime(2024, 6, 10, 14, 49, 18, 426, DateTimeKind.Utc).AddTicks(9453));

            migrationBuilder.UpdateData(
                table: "Aulas",
                keyColumn: "AulaId",
                keyValue: 2,
                column: "Data",
                value: new DateTime(2024, 6, 11, 14, 49, 18, 426, DateTimeKind.Utc).AddTicks(9455));

            migrationBuilder.UpdateData(
                table: "Aulas",
                keyColumn: "AulaId",
                keyValue: 3,
                column: "Data",
                value: new DateTime(2024, 6, 12, 14, 49, 18, 426, DateTimeKind.Utc).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "Aulas",
                keyColumn: "AulaId",
                keyValue: 4,
                columns: new[] { "Data", "SalaId" },
                values: new object[] { new DateTime(2024, 6, 13, 14, 49, 18, 426, DateTimeKind.Utc).AddTicks(9462), 0 });
        }
    }
}
