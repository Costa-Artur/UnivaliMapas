using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UnivaliMapas.Migrations
{
    /// <inheritdoc />
    public partial class UserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CodigoPessoa = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UserId", "CodigoPessoa", "Cpf", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "7888888", "000.000.000-00", "Vinicius Setti", "5phLUbbFkT1Kzcr0uGJgdCRUjWtXPqvQPIGjNkv17w0=" },
                    { 2, "7888888", "000.000.000-00", "Alisson Pokrywiecki", "5phLUbbFkT1Kzcr0uGJgdCRUjWtXPqvQPIGjNkv17w0=" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
