using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

namespace YourNamespace.Data {
    public class AnimeContext : DbContext {
        public AnimeContext(DbContextOptions<AnimeContext> options) : base(options) { }

        public DbSet<Pais> Paises { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }
    }
}
