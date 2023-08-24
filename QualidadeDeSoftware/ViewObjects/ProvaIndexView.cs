using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using QualidadeDeSoftware.Data.Models;

namespace QualidadeDeSoftware.ViewObjects
{
    public class ProvaIndexView
    {
        public int Id { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:D2}")]
        public string Nota { get; set; } = string.Empty!;

        [Display(Name = "Final")]
        public bool EhFinal { get; set; }

        [Display(Name = "Aluno")]
        public int AlunoId { get; set; }

        [ValidateNever]
        public Aluno Aluno { get; set; } = new Aluno();
    }
}