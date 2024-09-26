using CQRS.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Persistence;

public class ProizvodDbContext : DbContext
{
    public ProizvodDbContext(DbContextOptions<ProizvodDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<Proizvod> Proizvodi { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Proizvod>().HasKey(p => p.Id);
        modelBuilder.Entity<Proizvod>().HasData(
            new Proizvod("Fender Player Stratocaster HSS MN Buttercream", "Buttercream, HSS, 22 frets", 92990m),
            new Proizvod("Yamaha Pacifica120H Vintage White", "White, HSS, 24 frets", 49890m),
            new Proizvod("Ibanez RG350DXZ-WH White", "White, SSS, 24 frets", 63820m)
        );
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("proizvodi");
    }
}