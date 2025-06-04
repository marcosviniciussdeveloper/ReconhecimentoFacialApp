using Microsoft.EntityFrameworkCore;
using ReconhecimentoFacialApp.Models;


namespace ReconhecimentoFacialApp.Data
{


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ValidacaoFacial> ValidacoesFaciais { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<ValidacaoFacial>().ToTable("validacoes_faciais");

            base.OnModelCreating(modelBuilder);
        }


    }
}
