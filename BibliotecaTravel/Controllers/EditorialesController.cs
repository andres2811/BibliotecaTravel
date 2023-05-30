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
    [Route("api/Editoriales")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class EditorialesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EditorialesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("Editoriales")]
        public async Task<ActionResult<List<EditorialDto>>> Editoriales()
        {
            var Editoriales = await _context.Editorial.ToListAsync();
            return _mapper.Map<List<EditorialDto>>(Editoriales);
        }

        [HttpPost("AddEditorial")]
        public async Task<ActionResult> AddEditorial(EditorialeDto editoriale)
        {
            var editorial = new Editoriale
            {
                Nombre = editoriale.Nombre,
                Sede =  editoriale.Sede
            };

            await _context.Editorial.AddAsync(editorial);
            await _context.SaveChangesAsync();

            return Ok("Se ha registrado la editorial satisfactoriamente");
        }
    }
}
