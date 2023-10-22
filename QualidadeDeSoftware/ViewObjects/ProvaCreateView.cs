using System.ComponentModel.DataAnnotations;

namespace QualidadeDeSoftware.ViewObjects
{
    public class ProvaCreateView
    {
        public string Nota { get; set; } = string.Empty!;

        [Display(Name = "Final")]
        public bool EhFinal { get; set; }

        public int AlunoId { get; set; }
        public string Aluno { get; set; } = string.Empty!;
    }
}