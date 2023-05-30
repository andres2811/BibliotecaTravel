using AutoMapper;
using BibliotecaTravel.Dtos;
using BibliotecaTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaTravel.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Autore, AutoreDto >();
            CreateMap<Editoriale,EditorialeDto>();

            CreateMap<Autore, AutorDto>();
            CreateMap<Editoriale, EditorialDto>();


            CreateMap<Libro, LibroDto>();
            CreateMap<Libro, LibroDtoAutores>().ForMember(LibroDTO => LibroDTO.Autores, opciones => opciones.MapFrom(MapLibroDTIOAutores));
            CreateMap<LibroCreacionDto, Libro>().ForMember(libro => libro.AutoresLibros, opciones => opciones.MapFrom(MapAutoresLibros));
        }

        private List<AutorDto> MapLibroDTIOAutores(Libro libro, LibroDto libroDTO)
        {
            var resultado = new List<AutorDto>();

            if (libro.AutoresLibros == null)
            {
                return resultado;
            }

            foreach (var autorlibro in libro.AutoresLibros)
            {
                resultado.Add(new AutorDto()
                {
                    Id = autorlibro.Autor.Id,
                    Nombre = autorlibro.Autor.Nombre,
                    Apellidos = autorlibro.Autor.Apellidos
                });
            }

            return resultado;
        }

        private List<Autore_has_libro> MapAutoresLibros(LibroCreacionDto librocreacionDTO, Libro libro)
        {
            var resultado = new List<Autore_has_libro>();

            if (librocreacionDTO == null)
            {
                return resultado;
            }

            foreach (var autorId in librocreacionDTO.AutoresId)
            {
                resultado.Add(new Autore_has_libro()
                {
                    AutorId = autorId
                });
            }

            return resultado;
        }
    }
}
