using BibliotecaTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaTravel.Dtos
{
    public class LibroDto
    {
        public int Isbn { get; set; }
        public Editoriale Editorial { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string N_Paginas { get; set; }
    }
}
