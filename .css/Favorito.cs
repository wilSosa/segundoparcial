namespace YourNamespace.Models {
    public class Favorito {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int MangaId { get; set; }
        public Manga Manga { get; set; }
    }
}
