using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BibliotecaTravel.Models
{
    public class Libro
    {
        [Key]
        [MaxLength(45)]
        public int Isbn { get; set; }

        [ForeignKey("Editorial")]
        [MaxLength(10)]
        public int IdEditorial { get; set; }
        //objeto que representa la cla externa 
        [ForeignKey("IdEditorial")]
        public Editoriale Editorial { get; set; }
        [MaxLength(45)]
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        [MaxLength(45)]
        public string N_paginas { get; set; }
        public List<Autore_has_libro> AutoresLibros { get; set; }
    }
}
