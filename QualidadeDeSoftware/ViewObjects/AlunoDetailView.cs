using System.ComponentModel.DataAnnotations;
using QualidadeDeSoftware.Data.Models;

namespace QualidadeDeSoftware.ViewObjects;

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
            Id = aluno.Id,
            Nome = aluno.Nome,
            Exercicios = aluno.Exercicios.Select(x => (x.Id, x.ExercicioProgramado.Nome, x.EstaAdequado)),
            Provas = aluno.Provas.Select(x => (x.Id, x.Nota.ToString("0.00"), x.EhFinal))
        };
    }
}