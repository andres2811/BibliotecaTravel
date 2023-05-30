using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BibliotecaTravel.Models
{
    public class Autore
    {
        [Key]
        [MaxLength(10)]
        public int Id { get; set; }
        [MaxLength(45)]
        public string Nombre { get; set; }
        [MaxLength(45)]
        public string Apellidos { get; set; }
        public List<Autore_has_libro> AutoresLibros { get; set; }
    }
}
