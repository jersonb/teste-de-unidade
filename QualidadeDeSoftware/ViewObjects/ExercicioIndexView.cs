using System.ComponentModel.DataAnnotations;
using QualidadeDeSoftware.Data.Models;

namespace QualidadeDeSoftware.ViewObjects
{
    public class ExercicioIndexView
    {
        public int Id { get; set; }

        [Display(Name = "Data da Entrega")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset DataEntrega { get; set; }

        [Display(Name = "Está Adequado")]
        public bool EstaAdequado { get; set; }

        [Display(Name = "Exercício Programado")]
        public string ExercicioProgramado { get; set; } = string.Empty!;

        [Display(Name = "Aluno")]
        public string Aluno { get; set; } = string.Empty!;

        public static implicit operator ExercicioIndexView(Exercicio exercicio)
        {
            return new ExercicioIndexView
            {
                Aluno = exercicio.Aluno.Nome,
                DataEntrega = exercicio.DataEntrega,
                EstaAdequado = exercicio.EstaAdequado,
                ExercicioProgramado = exercicio.ExercicioProgramado.Nome,
                Id = exercicio.Id
            };
        }
    }
}