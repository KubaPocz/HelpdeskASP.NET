using Microsoft.EntityFrameworkCore;

namespace HelpdeskWebAPI.Models;

public class HelpdeskDbContext : DbContext
{
    public HelpdeskDbContext(DbContextOptions<HelpdeskDbContext> options) : base(options) { }
    public DbSet<Kategoria> Kategorie { get; set; }
    public DbSet<Pracownik> Pracownicy { get; set; }
    public DbSet<Priorytet> Priorytety { get; set; }
    public DbSet<Rola> Role { get; set; }
    public DbSet<Status> Statusy { get; set; }
    public DbSet<Zgloszenie> Zgloszenia { get; set; }
}
