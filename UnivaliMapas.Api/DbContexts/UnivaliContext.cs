using Microsoft.EntityFrameworkCore;
using UnivaliMapas.Api.Entities;

namespace UnivaliMapas.Api.DbContexts;

public class UnivaliContext : DbContext
{
    public DbSet<Sala> Salas { get; set; } = null!;
    
    public UnivaliContext (DbContextOptions<UnivaliContext> options) : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var sala = modelBuilder.Entity<Sala>();
        
        sala
            .HasKey(sala => sala.SalaId);
        
        sala
            .Property(sala => sala.Number)
            .IsRequired();

        sala
            .HasData(
                new Sala { SalaId = 1, Number = 101 },
                new Sala { SalaId = 2, Number = 102 },
                new Sala { SalaId = 3, Number = 103 },
                new Sala { SalaId = 4, Number = 104 },
                new Sala { SalaId = 5, Number = 105 },
                new Sala { SalaId = 6, Number = 106 }
            );

            base.OnModelCreating(modelBuilder);
    }
}