using Microsoft.EntityFrameworkCore;
using UnivaliMapas.Api.Entities;
using UnivaliMapas.Api.Extensions;

namespace UnivaliMapas.Api.DbContexts
{
    public class UnivaliContext : DbContext
    {
        public DbSet<Sala> Salas { get; set; } = null!;
        public DbSet<Bloco> Blocos { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Materia> Materias { get; set; } = null!;
        public DbSet<AlunoMateria> AlunoMaterias { get; set; } = null!;
        public DbSet<Aula> Aulas { get; set; } = null!;
    
        public UnivaliContext (DbContextOptions<UnivaliContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Bloco configuration
            var bloco = modelBuilder.Entity<Bloco>();

            bloco.HasKey(bloco => bloco.BlocoID);

            bloco.Property(bloco => bloco.LetraBloco)
                .IsRequired();

            bloco.HasMany(bloco => bloco.Salas)
                .WithOne(s => s.Bloco)
                .HasForeignKey(s => s.BlocoId);

            bloco.HasData(
                new Bloco { BlocoID = 1, LetraBloco = 'A' },
                new Bloco { BlocoID = 2, LetraBloco = 'B' },
                new Bloco { BlocoID = 3, LetraBloco = 'C' }
            );

            // Sala configuration
            var sala = modelBuilder.Entity<Sala>();

            sala.HasKey(sala => sala.SalaId);

            sala.Property(sala => sala.Number)
                .IsRequired();

            sala.HasMany(sala => sala.Aulas)
                .WithOne(a => a.Sala)
                .HasForeignKey(a => a.SalaId);

            sala.HasData(
                new Sala { SalaId = 1, Number = 101, BlocoId = 1 },
                new Sala { SalaId = 2, Number = 102, BlocoId = 1 },
                new Sala { SalaId = 3, Number = 103, BlocoId = 2 },
                new Sala { SalaId = 4, Number = 104, BlocoId = 2 },
                new Sala { SalaId = 5, Number = 105, BlocoId = 3 },
                new Sala { SalaId = 6, Number = 106, BlocoId = 3 }
            );

            // Usuario configuration
            var usuario = modelBuilder.Entity<Usuario>();

            usuario.HasKey(u => u.UserId);

            usuario.HasMany(u => u.MateriasMinistradas)
                .WithOne(m => m.Professor)
                .HasForeignKey(m => m.ProfessorId);

            usuario.HasMany(u => u.MateriasAssistidas)
                .WithMany(m => m.Alunos)
                .UsingEntity<AlunoMateria>(am => 
                {
                    am.HasKey(am => new { am.UserId, am.MateriaId });
                    am.ToTable("AlunoMateria");
                });

            usuario.HasData(
                new Usuario
                {
                    UserId = 1,
                    Name = "Vinicius Setti",
                    Cpf = "000.000.000-00",
                    CodigoPessoa = "7888888",
                    Password = PasswordHasherExtension.ComputeHash("senha123", "salt", "pepper", 10)
                },
                new Usuario
                {
                    UserId = 2,
                    Name = "Alisson Pokrywiecki",
                    Cpf = "000.000.000-00",
                    CodigoPessoa = "7888888",
                    Password = PasswordHasherExtension.ComputeHash("senha123", "salt", "pepper", 10),
                });

            // Materia configuration
            var materia = modelBuilder.Entity<Materia>();

            materia.HasKey(materia => materia.MateriaId);

            materia.HasMany<Aula>()
                .WithOne(a => a.Materia)
                .HasForeignKey(a => a.MateriaId);

            materia.HasData(
                new Materia()
                {
                    MateriaId = 1,
                    Name = "Engenharia de Software",
                    ProfessorId = 1
                },
                new Materia()
                {
                    MateriaId = 2,
                    Name = "Sistemas Operacionais",
                    ProfessorId = 2
                });

            // AlunoMateria configuration
            var alunoMateria = modelBuilder.Entity<AlunoMateria>();

            alunoMateria.HasKey(am => new { am.UserId, am.MateriaId });

            alunoMateria.HasData(
                new AlunoMateria { UserId = 1, MateriaId = 1 },
                new AlunoMateria { UserId = 2, MateriaId = 1 });

            // Aula configuration
            var aulas = modelBuilder.Entity<Aula>();

            aulas.HasKey(aula => aula.AulaId);

            aulas.Property(a => a.MateriaId).IsRequired();
            aulas.Property(a => a.SalaId).IsRequired();

            aulas.HasOne(a => a.Materia)
                .WithMany(m => m.Aulas)
                .HasForeignKey(a => a.MateriaId);

            aulas.HasOne(a => a.Sala)
                .WithMany(s => s.Aulas)
                .HasForeignKey(a => a.SalaId);

            aulas.HasData(
                new Aula
                {
                    AulaId = 1,
                    Data = DateTime.UtcNow,  // Ensure this is in UTC
                    MateriaId = 1,
                    SalaId = 1
                });


            base.OnModelCreating(modelBuilder);
}

    }
}