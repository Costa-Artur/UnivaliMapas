using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnivaliMapas.Migrations
{
    /// <inheritdoc />
    public partial class migracao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Aulas",
                keyColumn: "AulaId",
                keyValue: 1,
                column: "Data",
                value: new DateTime(2024, 6, 9, 22, 54, 18, 130, DateTimeKind.Utc).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "Aulas",
                keyColumn: "AulaId",
                keyValue: 2,
                column: "Data",
                value: new DateTime(2024, 6, 10, 22, 54, 18, 130, DateTimeKind.Utc).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "Aulas",
                keyColumn: "AulaId",
                keyValue: 3,
                column: "Data",
                value: new DateTime(2024, 6, 11, 22, 54, 18, 130, DateTimeKind.Utc).AddTicks(9600));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CodigoPessoa",
                value: "11111111");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CodigoPessoa",
                value: "22222222");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CodigoPessoa",
                value: "33333333");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Aulas",
                keyColumn: "AulaId",
                keyValue: 1,
                column: "Data",
                value: new DateTime(2024, 6, 9, 22, 52, 26, 333, DateTimeKind.Utc).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "Aulas",
                keyColumn: "AulaId",
                keyValue: 2,
                column: "Data",
                value: new DateTime(2024, 6, 10, 22, 52, 26, 333, DateTimeKind.Utc).AddTicks(6428));

            migrationBuilder.UpdateData(
                table: "Aulas",
                keyColumn: "AulaId",
                keyValue: 3,
                column: "Data",
                value: new DateTime(2024, 6, 11, 22, 52, 26, 333, DateTimeKind.Utc).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CodigoPessoa",
                value: "7888888");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CodigoPessoa",
                value: "7888888");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CodigoPessoa",
                value: "7888888");
        }
    }
}
