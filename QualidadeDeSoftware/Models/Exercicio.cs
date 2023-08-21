using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace QualidadeDeSoftware.Models
{
    public class Exercicio
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Data da Entrega")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset DataEntrega { get; set; }

        [Display(Name = "Está Adequado")]
        public bool EstaAdequado { get; set; }

        [Display(Name = "Exercício Programado")]
        public int ExercicioProgramadoId { get; set; }

        [Display(Name = "Exercício Programado")]
        [ValidateNever]
        public ExercicioProgramado ExercicioProgramado { get; set; } = default!;

        [Display(Name = "Aluno")]
        public int AlunoId { get; set; }

        [ValidateNever]
        public Aluno Aluno { get; set; } = new Aluno();
    }
}