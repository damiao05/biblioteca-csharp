using Microsoft.EntityFrameworkCore;
using Biblioteca.Api.Models;

namespace Biblioteca.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .HasOne(l => l.Usuario)
                .WithMany(u => u.HistoricoLogins)
                .HasForeignKey(l => l.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Endereco)
                .WithMany(a => a.Usuarios)
                .HasForeignKey(u => u.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.DataNascimento)
                .HasColumnType("date");

            base.OnModelCreating(modelBuilder);
        }

    }
}
