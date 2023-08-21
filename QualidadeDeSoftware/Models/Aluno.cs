using System.ComponentModel.DataAnnotations;

namespace QualidadeDeSoftware.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty!;
        public List<Prova> Provas { get; set; }
        public List<Exercicio> Exercicios { get; set; }
    }
}
