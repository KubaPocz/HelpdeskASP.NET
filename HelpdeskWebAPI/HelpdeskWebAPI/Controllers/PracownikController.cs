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
            var kategorie = await _context.Categories.ToListAsync();
            return Ok(kategorie);
        }
        [HttpGet("priorytety")]
        public async Task<IActionResult> PobierzPriorytety()
        {
            var priorytety = await _context.Priorities.ToListAsync();
            return Ok(priorytety);
        }
        [HttpGet("statusy")]
        public async Task<IActionResult> PobierzStatusy()
        {
            var statusy = await _context.States.ToListAsync();
            return Ok(statusy);
        }
        [HttpPost]
        public async Task<IActionResult> NoweZgloszenie([FromBody] Report zgloszenie)
        {
            zgloszenie.StateId = 1;
            zgloszenie.ReportDate = DateTime.Now;
            zgloszenie.WorkerId_ModeratedBy = null;

            _context.Reports.Add(zgloszenie);
            await _context.SaveChangesAsync();
            return Ok(new { komunikat = $"Zgłoszenie {zgloszenie.Title} zostało przyjęte" });
        }
    }
}
