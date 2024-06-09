using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UnivaliMapas.Migrations
{
    /// <inheritdoc />
    public partial class migracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CodigoPessoa = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    BlocoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                    table.ForeignKey(
                        name: "FK_Salas_Blocos_BlocoId",
                        column: x => x.BlocoId,
                        principalTable: "Blocos",
                        principalColumn: "BlocoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    MateriaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProfessorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.MateriaId);
                    table.ForeignKey(
                        name: "FK_Materias_Usuarios_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Usuarios",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoMateria",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MateriaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoMateria", x => new { x.UserId, x.MateriaId });
                    table.ForeignKey(
                        name: "FK_AlunoMateria_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoMateria_Usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuarios",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    AulaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MateriaId = table.Column<int>(type: "integer", nullable: false),
                    SalaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.AulaId);
                    table.ForeignKey(
                        name: "FK_Aulas_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aulas_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UserId", "CodigoPessoa", "Cpf", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "7888888", "000.000.000-00", "Vinicius Setti", "5phLUbbFkT1Kzcr0uGJgdCRUjWtXPqvQPIGjNkv17w0=", 0 },
                    { 2, "7888888", "000.000.000-00", "Alisson Pokrywiecki", "5phLUbbFkT1Kzcr0uGJgdCRUjWtXPqvQPIGjNkv17w0=", 0 },
                    { 3, "7888888", "000.000.000-00", "Thiago Felski", "5phLUbbFkT1Kzcr0uGJgdCRUjWtXPqvQPIGjNkv17w0=", 1 }
                });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "MateriaId", "Name", "ProfessorId" },
                values: new object[,]
                {
                    { 1, "Engenharia de Software", 3 },
                    { 2, "Sistemas Operacionais", 3 }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaId", "BlocoId", "Number" },
                values: new object[,]
                {
                    { 1, 1, 101 },
                    { 2, 1, 102 },
                    { 3, 2, 103 },
                    { 4, 2, 104 },
                    { 5, 3, 105 },
                    { 6, 3, 106 }
                });

            migrationBuilder.InsertData(
                table: "AlunoMateria",
                columns: new[] { "MateriaId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Aulas",
                columns: new[] { "AulaId", "Data", "MateriaId", "SalaId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 9, 22, 52, 26, 333, DateTimeKind.Utc).AddTicks(6425), 1, 1 },
                    { 2, new DateTime(2024, 6, 10, 22, 52, 26, 333, DateTimeKind.Utc).AddTicks(6428), 2, 5 },
                    { 3, new DateTime(2024, 6, 11, 22, 52, 26, 333, DateTimeKind.Utc).AddTicks(6435), 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoMateria_MateriaId",
                table: "AlunoMateria",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_MateriaId",
                table: "Aulas",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_SalaId",
                table: "Aulas",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_ProfessorId",
                table: "Materias",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Salas_BlocoId",
                table: "Salas",
                column: "BlocoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoMateria");

            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Blocos");
        }
    }
}
