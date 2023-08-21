using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using QualidadeDeSoftware.Models;

#nullable disable

namespace QualidadeDeSoftware.Data.Migrations
{
    public partial class CargaAlunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            new Faker<Aluno>(locale: "pt_BR")
                 .RuleFor(x => x.Nome, x => x.Person.FullName)
                 .Generate(10)
                 .ForEach(x => migrationBuilder.InsertData("Aluno", "Nome", new object[] { x.Nome }));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = "truncate table Aluno;";
            migrationBuilder.Sql(sql);
        }
    }
}