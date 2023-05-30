using BibliotecaTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaTravel.Dtos
{
    public class LibroDtoAutores : LibroDto
    {
        public List<AutorDto> Autores { get; set; }
    }
}
