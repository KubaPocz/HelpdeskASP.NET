using Microsoft.AspNetCore.Mvc;
using HelpdeskWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracownikController : ControllerBase
    {
        private readonly HelpdeskDbContext _context;

        public PracownikController(HelpdeskDbContext context)
        {
            _context = context;
        }
        [HttpGet("kategorie")]
        public async Task<IActionResult> PobierzKategorie()
        {
            var kategorie = await _context.Kategorie.ToListAsync();
            return Ok(kategorie);
        }
        [HttpGet("priorytety")]
        public async Task<IActionResult> PobierzPriorytety()
        {
            var priorytety = await _context.Priorytety.ToListAsync();
            return Ok(priorytety);
        }
        [HttpGet("statusy")]
        public async Task<IActionResult> PobierzStatusy()
        {
            var statusy = await _context.Statusy.ToListAsync();
            return Ok(statusy);
        }
        [HttpPost]
        public async Task<IActionResult> NoweZgloszenie([FromBody] Zgloszenie zgloszenie)
        {
            zgloszenie.StatusId = 1;
            zgloszenie.DataUtworzenia = DateTime.Now;

            _context.Zgloszenia.Add(zgloszenie);
            await _context.SaveChangesAsync();
            return Ok(new { komunikat = $"Zgłoszenie {zgloszenie.Tytul} zostało przyjęte" });
        }
    }
}
