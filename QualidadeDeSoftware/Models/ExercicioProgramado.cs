using System.ComponentModel.DataAnnotations;

namespace QualidadeDeSoftware.Models
{
    public class ExercicioProgramado
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty!;
        public DateTimeOffset DataLimite { get; set; }
    }
}