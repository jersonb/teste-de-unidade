using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace QualidadeDeSoftware.Data.Models
{
    public class Prova
    {
        [Key]
        public int Id { get; set; }
        public decimal Nota { get; set; }

        [Display(Name = "Final")]
        public bool EhFinal { get; set; }

        [Display(Name = "Aluno")]
        public int AlunoId { get; set; }

        [ValidateNever]
        public Aluno Aluno { get; set; } = new Aluno();
    }
}