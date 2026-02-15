namespace LibreriaAPI.DTOs
{
    public class LibroDTO
    {
        public int IdLibro { get; set; }
        public string? Titulo { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string? Autor { get; set; }
        public string? TipoLibro { get; set; }
    }
}
