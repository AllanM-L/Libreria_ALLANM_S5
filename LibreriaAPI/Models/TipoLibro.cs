using System.ComponentModel.DataAnnotations;

namespace LibreriaAPI.Models
{
    public class TipoLibro
    {
        [Key]
        public int IdTipo { get; set; }

        [Required]
        [MaxLength(100)]
        public string? NombreTipo { get; set; }

        [MaxLength(200)]
        public string? Descripcion { get; set; }

        public ICollection<Libro>? Libros { get; set; }
    }
}
