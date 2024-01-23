using LeanWork.Atividade3.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeanWork.Atividade3.Infra.Contexts;

public class LeanWorkContext : DbContext
{
    public LeanWorkContext(DbContextOptions<LeanWorkContext> options) : base(options)
    { }

    public virtual DbSet<Tecnologia> Tecnologias { get; set; }
    public virtual DbSet<Vaga> Vagas { get; set; }
    public virtual DbSet<Candidato> Candidatos { get; set; }
    public virtual DbSet<PesoTecnologiaVaga> PesosTecnologiaVaga { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var assembly = GetType().Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        modelBuilder.Entity<Tecnologia>().HasData(
            new Tecnologia { Id = 1, Nome = "C#" },
            new Tecnologia { Id = 2, Nome = "Angular" });
    }
}
