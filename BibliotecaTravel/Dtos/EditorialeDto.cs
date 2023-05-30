using System.ComponentModel.DataAnnotations;


namespace BibliotecaTravel.Dtos
{
    public class EditorialeDto
    {
        [MaxLength(45)]
        [Required]
        public string Nombre { get; set; }
        [MaxLength(45)]
        [Required]
        public string Sede { get; set; }
    }
}
