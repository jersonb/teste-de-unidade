using System.ComponentModel.DataAnnotations;
using QualidadeDeSoftware.Data.Models;

namespace QualidadeDeSoftware.ViewObjects
{
    public class AlunoIndexView
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; } = string.Empty!;

        public static implicit operator AlunoIndexView(Aluno aluno)
        {
            return new AlunoIndexView
            {
                Id = aluno.Id,
                Nome = aluno.Nome
            };
        }
    }

}