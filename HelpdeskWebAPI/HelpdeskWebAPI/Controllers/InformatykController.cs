using HelpdeskWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpdeskWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class InformatykController : ControllerBase
{
    private readonly HelpdeskDbContext _context;

    public InformatykController(HelpdeskDbContext context)
    {
        _context = context;
    }

    [HttpGet("zgloszenia/pobierz")]
    public async Task<IActionResult> PobierzZgloszenia()
    {
        var zgloszenia = _context.Zgloszenia.Where(z => z.StatusId == 1 || z.StatusId == 2);
        return Ok(zgloszenia);
    }

    [HttpPut("zgloszenia/aktualizuj/{id}")]
    public async Task<IActionResult> ZmienStatus([FromBody] Zgloszenie noweZglsozenie, int id)
    {
        var zgloszenieZBazy = _context.Zgloszenia.FirstOrDefault(z=> z.Id == id);
        if (zgloszenieZBazy == null)
            return BadRequest($"Nie znaleziono zgłoszenia! z ID:{id}");
        zgloszenieZBazy.Tytul = noweZglsozenie.Tytul;
        zgloszenieZBazy.Opis = noweZglsozenie.Opis;
        zgloszenieZBazy.StatusId = noweZglsozenie.StatusId;
        zgloszenieZBazy.KategoriaId = noweZglsozenie.KategoriaId;
        zgloszenieZBazy.PriorytetId = noweZglsozenie.PriorytetId;

        _context.SaveChanges();
        return Ok($"Produkt z ID: {id} został zmieniony pomyślnie");
    }
}
