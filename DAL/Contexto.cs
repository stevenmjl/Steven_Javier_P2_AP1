using Microsoft.EntityFrameworkCore;
using Steven_Javier_P2_AP1.Models;

namespace Steven_Javier_P2_AP1.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudades>().HasData(
            new List<Ciudades>()
            {
                new()
                {
                    Id = 1,
                    Nombre = "Moca",
                    Monto = 14000
                },
                new()
                {
                    Id = 2,
                    Nombre = "Santo Domingo",
                    Monto = 35000
                },
                new()
                {
                    Id = 3,
                    Nombre = "La Vega",
                    Monto = 20000
                }
            }
        );
        base.OnModelCreating(modelBuilder);
    }
}