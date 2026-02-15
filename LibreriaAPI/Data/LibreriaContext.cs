using Microsoft.EntityFrameworkCore;
using LibreriaAPI.Models;

namespace LibreriaAPI.Data
{
    public class LibreriaContext : DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options)
            : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<TipoLibro> TipoLibros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Autor>().ToTable("autores");
            modelBuilder.Entity<TipoLibro>().ToTable("tipolibro");
            modelBuilder.Entity<Libro>().ToTable("libros");

            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Autor)
                .WithMany(a => a.Libros)
                .HasForeignKey(l => l.IdAutor);

            modelBuilder.Entity<Libro>()
                .HasOne(l => l.TipoLibro)
                .WithMany(t => t.Libros)
                .HasForeignKey(l => l.IdTipo);
        }

    }
}
