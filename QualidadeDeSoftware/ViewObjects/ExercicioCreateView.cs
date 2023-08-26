using System.ComponentModel.DataAnnotations;

namespace QualidadeDeSoftware.ViewObjects;

public class ExercicioCreateView
{
    [Display(Name = "Data da Entrega")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime DataEntrega { get; set; } = DateTime.Now;

    [Display(Name = "Está Adequado")]
    public bool EstaAdequado { get; set; }

    [Display(Name = "Exercício Programado")]
    public int ExercicioProgramadoId { get; set; }

    [Display(Name = "Aluno")]
    public int AlunoId { get; set; }

    [Display(Name = "Aluno")]
    public string Aluno { get; set; } = string.Empty!;
}