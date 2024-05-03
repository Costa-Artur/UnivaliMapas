using Microsoft.EntityFrameworkCore;
using UnivaliMapas.Api.Entities;

namespace UnivaliMapas.Api.DbContexts;

//dotnet ef migrations add NomeMigration
//dotnet ef database update

public class UnivaliContext : DbContext
{
    public DbSet<Sala> Salas { get; set; } = null!;
    public DbSet<Bloco> Blocos { get; set; } = null!;
    
    public UnivaliContext (DbContextOptions<UnivaliContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var bloco = modelBuilder.Entity<Bloco>();

        bloco
            .HasKey(bloco => bloco.BlocoID);

        bloco
            .Property(bloco => bloco.LetraBloco)
            .IsRequired();

        bloco
            .HasMany(bloco => bloco.Salas)
            .WithOne(s => s.Bloco)
            .HasForeignKey(s => s.BlocoId);

        bloco
            .HasData(
                new Bloco { BlocoID = 1, LetraBloco = 'A'}, 
                new Bloco { BlocoID = 2, LetraBloco = 'B'},
                new Bloco { BlocoID = 3, LetraBloco = 'C'}
            );
        
        var sala = modelBuilder.Entity<Sala>();
        
        sala
            .HasKey(sala => sala.SalaId);
        
        sala
            .Property(sala => sala.Number)
            .IsRequired();

        sala
            .HasData(
                new Sala { SalaId = 1, Number = 101, BlocoId = 1},
                new Sala { SalaId = 2, Number = 102, BlocoId = 1 },
                new Sala { SalaId = 3, Number = 103, BlocoId = 2 },
                new Sala { SalaId = 4, Number = 104, BlocoId = 2 },
                new Sala { SalaId = 5, Number = 105, BlocoId = 3 },
                new Sala { SalaId = 6, Number = 106, BlocoId = 3 }
            );
            
            
            
            base.OnModelCreating(modelBuilder);
            
    }
    
}