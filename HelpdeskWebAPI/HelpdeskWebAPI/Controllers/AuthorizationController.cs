using HelpdeskWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly HelpdeskDbContext _context;

        public AuthorizationController(HelpdeskDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto daneLogowania)
        {
            var pracownik = await _context.Workers.FirstOrDefaultAsync(p=>p.Login == daneLogowania.Login);

            if(pracownik == null)
            {
                return Unauthorized("Nieprawidłowy login lub hasło");
            }

            if(pracownik.Password != daneLogowania.Haslo)
            {
                return Unauthorized("Nieprawidłowy login lub hasło");
            }

            return Ok(new
            {
                Wiadomosc = "Zalogowano pomyślnie!",
                Imie = pracownik.Name,
                Nazwisko = pracownik.LastName,
                Rola = _context.Positions.FirstOrDefault(r => r.Id == pracownik.PositionId).Name
            });

        }
    }
}
