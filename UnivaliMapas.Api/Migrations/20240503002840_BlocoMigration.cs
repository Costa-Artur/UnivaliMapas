using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UnivaliMapas.Migrations
{
    /// <inheritdoc />
    public partial class BlocoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlocoId",
                table: "Salas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Blocos",
                columns: table => new
                {
                    BlocoID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LetraBloco = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocos", x => x.BlocoID);
                });

            migrationBuilder.InsertData(
                table: "Blocos",
                columns: new[] { "BlocoID", "LetraBloco" },
                values: new object[,]
                {
                    { 1, 'A' },
                    { 2, 'B' },
                    { 3, 'C' }
                });

            migrationBuilder.UpdateData(
                table: "Salas",
                keyColumn: "SalaId",
                keyValue: 1,
                column: "BlocoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Salas",
                keyColumn: "SalaId",
                keyValue: 2,
                column: "BlocoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Salas",
                keyColumn: "SalaId",
                keyValue: 3,
                column: "BlocoId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Salas",
                keyColumn: "SalaId",
                keyValue: 4,
                column: "BlocoId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Salas",
                keyColumn: "SalaId",
                keyValue: 5,
                column: "BlocoId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Salas",
                keyColumn: "SalaId",
                keyValue: 6,
                column: "BlocoId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Salas_BlocoId",
                table: "Salas",
                column: "BlocoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salas_Blocos_BlocoId",
                table: "Salas",
                column: "BlocoId",
                principalTable: "Blocos",
                principalColumn: "BlocoID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salas_Blocos_BlocoId",
                table: "Salas");

            migrationBuilder.DropTable(
                name: "Blocos");

            migrationBuilder.DropIndex(
                name: "IX_Salas_BlocoId",
                table: "Salas");

            migrationBuilder.DropColumn(
                name: "BlocoId",
                table: "Salas");
        }
    }
}
