using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnivaliMapas.Migrations
{
    /// <inheritdoc />
    public partial class migracaoseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CodigoPessoa",
                value: "78888818");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CodigoPessoa",
                value: "7888888");
        }
    }
}
