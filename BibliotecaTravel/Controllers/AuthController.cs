using BibliotecaTravel.Data;
using BibliotecaTravel.Dtos;
using BibliotecaTravel.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BibliotecaTravel.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _context;

        public AuthController(IConfiguration configuration, IUserService userService, ApplicationDbContext context)
        {
            _configuration = configuration;
            _userService = userService;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost(nameof(Auth))]
        public IActionResult Auth([FromBody] UserDto data)
        {
            var isValid = _context.Usuario.Where(x => x.UserName == data.UserName && x.Password == data.Password).FirstOrDefault();
            if (isValid != null)
            {
                var tokenString = GenerateJwtToken(data.UserName);
                return Ok(new { Token = tokenString, Message = "Success" });
            }
            return BadRequest("por favor validar el usuario y contraseña");
        }

        private string GenerateJwtToken(string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userName) }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
