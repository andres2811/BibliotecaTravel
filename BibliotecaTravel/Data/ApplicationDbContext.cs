using BibliotecaTravel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaTravel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Autore> Autor { get; set; }
        public DbSet<Autore_has_libro> Autores_Has_Libros { get; set; }
        public DbSet<Editoriale> Editorial { get; set; }
        public DbSet<Libro> Libro { get; set; }
        public DbSet<User> Usuario { get; set; }
    }
}
