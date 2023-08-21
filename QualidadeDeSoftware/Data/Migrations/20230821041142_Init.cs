using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualidadeDeSoftware.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExercicioProgramado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DataLimite = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercicioProgramado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prova",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nota = table.Column<decimal>(type: "TEXT", nullable: false),
                    EhFinal = table.Column<bool>(type: "INTEGER", nullable: false),
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prova", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prova_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataEntrega = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    EstaAdequado = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExercicioProgramadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercicio_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercicio_ExercicioProgramado_ExercicioProgramadoId",
                        column: x => x.ExercicioProgramadoId,
                        principalTable: "ExercicioProgramado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercicio_AlunoId",
                table: "Exercicio",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicio_ExercicioProgramadoId",
                table: "Exercicio",
                column: "ExercicioProgramadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prova_AlunoId",
                table: "Prova",
                column: "AlunoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercicio");

            migrationBuilder.DropTable(
                name: "Prova");

            migrationBuilder.DropTable(
                name: "ExercicioProgramado");

            migrationBuilder.DropTable(
                name: "Aluno");
        }
    }
}
