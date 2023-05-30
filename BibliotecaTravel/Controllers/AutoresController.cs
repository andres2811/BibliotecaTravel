using AutoMapper;
using BibliotecaTravel.Data;
using BibliotecaTravel.Dtos;
using BibliotecaTravel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaTravel.Controllers
{
    [Route("api/Autores")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class AutoresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AutoresController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("Autores")]
        public async Task<ActionResult<List<AutorDto>>> Autores()
        {
            var Autores = await _context.Autor.ToListAsync();
            return _mapper.Map<List<AutorDto>>(Autores);
        }

        [HttpPost("AddAutor")]
        public async Task<ActionResult> AddAutor(AutoreDto autore)
        {
            var autor = new Autore
            {
                Nombre = autore.Nombre,
                Apellidos = autore.Apellidos
            };

            await _context.Autor.AddAsync(autor);
            await _context.SaveChangesAsync();

            return Ok("Se ha registrado el autor satisfactoriamente");
        }
    }

}

