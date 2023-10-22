using System.ComponentModel.DataAnnotations;
using QualidadeDeSoftware.Data.Models;

namespace QualidadeDeSoftware.ViewObjects
{
    public class ProvaIndexView
    {
        public int Id { get; set; }

        public string Nota { get; set; } = string.Empty!;

        [Display(Name = "Final")]
        public bool EhFinal { get; set; }

        [Display(Name = "Aluno")]
        public string Aluno { get; set; } = string.Empty!;

        public static implicit operator ProvaIndexView(Prova prova)
        {
            return new ProvaIndexView
            {
                Id = prova.Id,
                Aluno = prova.Aluno.Nome,
                EhFinal = prova.EhFinal,
                Nota = prova.Nota.ToString("0.00"),
            };
        }
    }
}