using Karapinha.Model;
using Microsoft.EntityFrameworkCore;

namespace Karapinha.DAL
{
    public class KarapinhaContext : DbContext
    {
        public KarapinhaContext(DbContextOptions<KarapinhaContext> options) : base(options)
        {
        }

        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Marcacao> Marcacoes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<HorarioFuncionario> HorarioFuncionarios { get; set; }
        public DbSet<MarcacaoServico> MarcacaoServicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Profissional>()
                .HasOne(p => p.Categoria)
                .WithMany() // Configuração sem necessidade da lista em Categoria
                .HasForeignKey(p => p.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata de exclusão
        }
    }
}
