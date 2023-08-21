using System.ComponentModel.DataAnnotations;

namespace QualidadeDeSoftware.Models
{
    public class Exercicio
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Data da Entrega")]
        public DateTimeOffset DataEntrega { get; set; }

        [Display(Name = "Está Adequado")]
        public bool EstaAdequado { get; set; }

        [Display(Name = "Exercício Programado")]
        public int ExercicioProgramadoId { get; set; }

        [Display(Name = "Exercício Programado")]
        public ExercicioProgramado ExercicioProgramado { get; set; } = default!;

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; } = new Aluno();
    }
}