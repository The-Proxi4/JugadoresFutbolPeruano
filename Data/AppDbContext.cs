using Microsoft.EntityFrameworkCore;
using JugadoresFutbolPeruano.Models;

namespace JugadoresFutbolPeruano.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Evita duplicados en asignaciones
    modelBuilder.Entity<Assignment>()
        .HasIndex(a => new { a.PlayerId, a.TeamId })
        .IsUnique();

    // Equipos por defecto
    modelBuilder.Entity<Team>().HasData(
        new Team { Id = 1, Name = "Universitario" },
        new Team { Id = 2, Name = "Alianza Lima" },
        new Team { Id = 3, Name = "Sporting Cristal" }
    );
}

    }
}
