using Microsoft.EntityFrameworkCore.Migrations;
using QualidadeDeSoftware.Models;

#nullable disable

namespace QualidadeDeSoftware.Data.Migrations
{
    public partial class CargaExerciciosProgramados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            new List<ExercicioProgramado>
            {
                new ExercicioProgramado
                {
                    Nome = "Lista de Exercício 1",
                    DataLimite = DateTimeOffset.Now.AddDays(10),
                },
                new ExercicioProgramado
                {
                    Nome = "Lista de Exercício 2",
                    DataLimite = DateTimeOffset.Now.AddMonths(1),
                },
                new ExercicioProgramado
                {
                    Nome = "Estudo de caso",
                    DataLimite = DateTimeOffset.Now.AddMonths(1).AddDays(15),
                },new ExercicioProgramado
                {
                    Nome = "Seminário de Testes de unidade",
                    DataLimite = DateTimeOffset.Now.AddMonths(1).AddDays(15),
                }
            }.ForEach(x =>
            {
                migrationBuilder.InsertData("ExercicioProgramado", "Nome,DataLimite".Split(","), new object[] { x.Nome, x.DataLimite });
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("truncate table ExercicioProgramado;");
        }
    }
}