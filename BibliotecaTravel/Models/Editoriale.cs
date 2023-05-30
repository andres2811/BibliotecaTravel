using System.ComponentModel.DataAnnotations;


namespace BibliotecaTravel.Models
{
    public class Editoriale
    {
        [Key]
        [MaxLength(10)]
        public int Id { get; set; }
        [MaxLength(45)]
        public string Nombre { get; set; }
        [MaxLength(45)]
        public string Sede { get; set; }
    }
}
