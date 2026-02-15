using System.ComponentModel.DataAnnotations;

namespace LibreriaAPI.Models
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nombre { get; set; }

        [MaxLength(100)]
        public string? Nacionalidad { get; set; }

        public ICollection<Libro>? Libros { get; set; }
    }
}

