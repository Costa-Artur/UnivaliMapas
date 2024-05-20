using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnivaliMapas.Migrations
{
    /// <inheritdoc />
    public partial class migracaoseed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "senha123");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "senha123");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "5phLUbbFkT1Kzcr0uGJgdCRUjWtXPqvQPIGjNkv17w0=");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "5phLUbbFkT1Kzcr0uGJgdCRUjWtXPqvQPIGjNkv17w0=");
        }
    }
}
