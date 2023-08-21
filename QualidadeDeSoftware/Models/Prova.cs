using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace QualidadeDeSoftware.Models
{
    public class Prova
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Nota { get; set; }

        [Display(Name = "Final")]
        public bool EhFinal { get; set; }

        [Display(Name = "Aluno")]
        public int AlunoId { get; set; }

        [ValidateNever]
        public Aluno Aluno { get; set; } = new Aluno();
    }
}