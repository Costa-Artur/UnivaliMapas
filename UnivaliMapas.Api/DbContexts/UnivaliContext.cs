using Microsoft.EntityFrameworkCore;
using UnivaliMapas.Api.Entities;

namespace UnivaliMapas.Api.DbContexts;

public class UnivaliContext : DbContext
{
    public DbSet<Sala> Salas { get; set; } = null!;
    public DbSet<Bloco> Blocos { get; set; } = null!;
    
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

        /*sala
            .HasData(
                new Sala { SalaId = 1, Number = 101 },
                new Sala { SalaId = 2, Number = 102 },
                new Sala { SalaId = 3, Number = 103 },
                new Sala { SalaId = 4, Number = 104 },
                new Sala { SalaId = 5, Number = 105 },
                new Sala { SalaId = 6, Number = 106 }
            );*/

            base.OnModelCreating(modelBuilder);
            
            var bloco = modelBuilder.Entity<Bloco>();

            bloco
                .HasKey(bloco => bloco.BlocoID);

            bloco
                .Property(bloco => bloco.LetraBloco)
                .IsRequired();

            bloco
                .HasMany(bloco => bloco.Salas);

            bloco
                .HasData(
                    new Bloco { BlocoID = 1, LetraBloco = 'A', Salas = [new Sala{SalaId = 1, Number = 101}]}, 
                    new Bloco { BlocoID = 2, LetraBloco = 'B', Salas = [new Sala{SalaId = 2, Number = 102}]},
                    new Bloco { BlocoID = 3, LetraBloco = 'C', Salas = [new Sala{SalaId = 3, Number = 103}]},
                    new Bloco { BlocoID = 4, LetraBloco = 'D', Salas = [new Sala{SalaId = 4, Number = 104}]},
                    new Bloco { BlocoID = 5, LetraBloco = 'E', Salas = [new Sala{SalaId = 5, Number = 105}]},
                    new Bloco { BlocoID = 6, LetraBloco = 'F', Salas = [new Sala{SalaId = 6, Number = 106}]}
                );
            
            base.OnModelCreating(modelBuilder);
            
    }
    
}