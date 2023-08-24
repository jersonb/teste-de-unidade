using System.ComponentModel.DataAnnotations;

namespace QualidadeDeSoftware.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty!;
        public List<Prova> Provas { get; set; } = default!;
        public List<Exercicio> Exercicios { get; set; } = default!;
    }

    public class AlunoIndexView
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; } = string.Empty!;

        public static implicit operator AlunoIndexView(Aluno aluno)
        {
            return new AlunoIndexView
            {
                Id = aluno.Id,
                Nome = aluno.Nome
            };
        }
    }

    public class AlunoDetailView
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty!;

        [Display(Name = "Provas")]
        public IEnumerable<(int Id, string Nota, bool EhFinal)> Provas { get; set; } = default!;

        [Display(Name = "Exercícios")]
        public IEnumerable<(int Id, string Nome, bool EstaAdequado)> Exercicios { get; set; } = default!;

        public static implicit operator AlunoDetailView(Aluno aluno)
        {
            return new AlunoDetailView
            {
                Provas = aluno.Provas.Select(x => (x.Id, x.Nota.ToString("0.00"), x.EhFinal)),
                Id = aluno.Id,
                Nome = aluno.Nome,
                Exercicios = aluno.Exercicios.Select(x => (x.Id, x.ExercicioProgramado.Nome, x.EstaAdequado))
            };
        }
    }

}