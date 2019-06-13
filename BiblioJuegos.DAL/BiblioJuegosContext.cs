using System;
using BiblioJuegos.BOL;
using Microsoft.EntityFrameworkCore;

namespace BiblioJuegos.DAL
{
    public class BiblioJuegosContext : DbContext
    {
        public BiblioJuegosContext(DbContextOptions options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Compania> Companias { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<Videojuego> Videojuegos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
