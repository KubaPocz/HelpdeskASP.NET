using HelpdeskWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AdminController : ControllerBase
{
    private readonly HelpdeskDbContext _context;

    public AdminController(HelpdeskDbContext context)
    {
        _context = context;
    }
    [HttpGet("workers/get")]
    public async Task<IActionResult> PobierzPracownikow()
    {
        var wynik = from w in _context.Workers
                    join positions in _context.Positions on w.PositionId equals positions.Id
                    select new
                    {
                        Id = w.Id,
                        Name = w.Name,
                        LastName = w.LastName,
                        Position = positions.Name,
                        Email = w.Email
                    };
        return Ok(await wynik.ToListAsync());
    }
    [HttpGet("reports/get")]
    public async Task<IActionResult> PobierzZgloszenia()
    {
        var wynik = from z in _context.Reports
                    where z.StateId == 1 || z.StateId == 2
                    join worker_r in _context.Workers on z.WorkerId_ReportedBy equals worker_r.Id
                    join worker_m in _context.Workers on z.WorkerId_ModeratedBy equals worker_m.Id into moderatorGroup
                    from subWorkerM in moderatorGroup.DefaultIfEmpty()
                    join status in _context.States on z.StateId equals status.Id
                    select new
                    {
                        Id = z.Id,
                        Title = z.Title,
                        ReportedBy = worker_r.Name + " " + worker_r.LastName,
                        ModeratedBy = subWorkerM != null
                        ? subWorkerM.Name + " " + subWorkerM.LastName
                        : "nobody",
                        State = status.Name,
                        ReportDate = z.ReportDate
                    };
        return Ok(await wynik.ToListAsync());
    }

    [HttpPut("reports/update/{id}")]
    public async Task<IActionResult> ZmienStatus([FromBody] Report noweZglsozenie, int id)
    {
        var zgloszenieZBazy = _context.Reports.FirstOrDefault(z => z.Id == id);
        if (zgloszenieZBazy == null)
            return BadRequest($"Nie znaleziono zgłoszenia! z ID:{id}");
        zgloszenieZBazy.Title = noweZglsozenie.Title;
        zgloszenieZBazy.Description = noweZglsozenie.Description;
        zgloszenieZBazy.StateId = noweZglsozenie.StateId;
        zgloszenieZBazy.CategoryId = noweZglsozenie.CategoryId;
        zgloszenieZBazy.PriorityId = noweZglsozenie.PriorityId;

        _context.SaveChanges();
        return Ok($"Produkt z ID: {id} został zmieniony pomyślnie");
    }
}
