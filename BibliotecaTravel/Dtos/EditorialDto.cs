using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaTravel.Dtos
{
    public class EditorialDto
    {
        public int Id { get; set; }
        [MaxLength(45)]
        [Required]
        public string Nombre { get; set; }
        [MaxLength(45)]
        [Required]
        public string Sede { get; set; }
    }
}
