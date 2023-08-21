using System.ComponentModel.DataAnnotations;

namespace QualidadeDeSoftware.Models
{
    public class Exercicio
    {
        [Key]
        public int Id { get; set; }

        public DateTimeOffset DataEntrega { get; set; }
        public bool EstaAdequado { get; set; }
        public int ExercicioProgramadoId { get; set; }
        public ExercicioProgramado ExercicioProgramado { get; set; } = default!;
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; } = new Aluno();
    }
}