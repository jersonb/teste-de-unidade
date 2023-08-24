using Microsoft.EntityFrameworkCore;
using QualidadeDeSoftware.Data.Models;

namespace QualidadeDeSoftware.Data
{
    public class QualidadeDeSoftwareContext : DbContext
    {
        public QualidadeDeSoftwareContext(DbContextOptions<QualidadeDeSoftwareContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Aluno { get; set; } = default!;

        public DbSet<Prova> Prova { get; set; } = default!;

        public DbSet<Exercicio> Exercicio { get; set; } = default!;

        public DbSet<ExercicioProgramado> ExercicioProgramado { get; set; } = default!;
    }
}