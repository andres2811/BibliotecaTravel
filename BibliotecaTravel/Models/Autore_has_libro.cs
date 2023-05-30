using System.ComponentModel.DataAnnotations;

namespace BibliotecaTravel.Models
{
    public class Autore_has_libro
    {
        [Key]
        public int Id { get; set; }
        public int LibroId { get; set; }
        public int AutorId { get; set; }
        public Libro Libro { get; set;}
        public Autore Autor { get; set; }
    }
}
