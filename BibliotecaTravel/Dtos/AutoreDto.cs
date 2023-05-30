using System.ComponentModel.DataAnnotations;

namespace BibliotecaTravel.Dtos
{
    public class AutoreDto
    {
        [MaxLength(45)]
        [Required]
        public string Nombre { get; set; }
        [MaxLength(45)]
        [Required]
        public string Apellidos { get; set; }
    }
}
