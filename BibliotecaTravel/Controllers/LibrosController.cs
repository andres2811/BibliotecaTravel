using AutoMapper;
using BibliotecaTravel.Data;
using BibliotecaTravel.Dtos;
using BibliotecaTravel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaTravel.Controllers
{
    [Route("api/Libros")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LibrosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("LibrosConAutores/{id}")]
        public async Task<ActionResult<LibroDtoAutores>> LibrosConAutores(int id)
        {
            var libro = await _context.Libro.Include(LibroBD => LibroBD.AutoresLibros).ThenInclude(autorLibro => autorLibro.Autor).FirstOrDefaultAsync(x => x.Isbn == id);
            return _mapper.Map<LibroDtoAutores>(libro);
        }

        [HttpPost("AddLibro")]
        public async Task<ActionResult> AddLibro(LibroCreacionDto librocreacionDto)
        { 
            //verifica si existe editorial
            var Editorial = await _context.Editorial.Where(editorial => editorial.Id == librocreacionDto.IdEditorial).FirstOrDefaultAsync();
            if(Editorial == null)
            {
                return BadRequest("No existe la editorial ingresada");
            }

            //verifica existencia de autores
            var AutoresIds = await _context.Autor.Where(AutorBD => librocreacionDto.AutoresId.Contains(AutorBD.Id)).Select(x => x.Id).ToListAsync();

            // iguala cantidades entre autores ingresados y existentes
            if (librocreacionDto.AutoresId.Count != AutoresIds.Count)
            {
                return BadRequest("No Existe uno o varios de los autores creados");
            }

            var libro = _mapper.Map<Libro>(librocreacionDto);

            _context.Add(libro);
            await _context.SaveChangesAsync();
            return Ok("Se ha registrado el Libro con exito");
        }
    }
}
