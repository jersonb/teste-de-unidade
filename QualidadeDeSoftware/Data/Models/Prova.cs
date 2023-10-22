using System.ComponentModel.DataAnnotations;

namespace QualidadeDeSoftware.Data.Models
{
    public class Prova
    {
        [Key]
        public int Id { get; set; }

        public decimal Nota { get; set; }

        public bool EhFinal { get; set; }

        public int AlunoId { get; set; }

        public Aluno Aluno { get; set; } = default!;
    }
}