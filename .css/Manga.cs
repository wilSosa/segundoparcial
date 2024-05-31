namespace YourNamespace.Models {
    public class Manga {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int Temporadas { get; set; }
        public bool Anime { get; set; }
        public bool Juego { get; set; }
        public bool Pelicula { get; set; }
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }
    }
}
