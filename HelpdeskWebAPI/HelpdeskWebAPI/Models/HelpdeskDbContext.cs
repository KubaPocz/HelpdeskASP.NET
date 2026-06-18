using Microsoft.EntityFrameworkCore;

namespace HelpdeskWebAPI.Models;

public class HelpdeskDbContext : DbContext
{
    public HelpdeskDbContext(DbContextOptions<HelpdeskDbContext> options) : base(options) { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Priority> Priorities { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Report> Reports { get; set; }
}
