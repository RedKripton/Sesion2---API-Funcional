using System.ComponentModel.DataAnnotations;

namespace Sesion2___API_Funcional.Models
{
    public class Alumno
    {
        [Key]
        [Required]
        public long Matricula { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Apellidos { get; set; } = null!;
        public long Telefono { get; set; }
        [Required]
        public int Edad { get; set; }
        public string? UrlImagen { get; set; }
        public long Adeudos { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public DateTime FechaDeModificacion { get; set; }

    }
}
