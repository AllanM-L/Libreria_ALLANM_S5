using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaAPI.Models
{
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }

        [Required]
        [MaxLength(150)]
        public string? Titulo { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }

        public int Stock { get; set; }

        [ForeignKey("Autor")]
        public int IdAutor { get; set; }

        [ForeignKey("TipoLibro")]
        public int IdTipo { get; set; }

        public Autor? Autor { get; set; }
        public TipoLibro? TipoLibro { get; set; }
    }
}

