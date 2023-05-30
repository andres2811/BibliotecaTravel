using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BibliotecaTravel.Dtos
{
    public class LibroCreacionDto
    {
        [Required]
        public int IdEditorial { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Sinopsis { get; set; }
        [Required]
        public string N_paginas { get; set; }
        [Required]
        public List<int> AutoresId { get; set; }
    }
}
