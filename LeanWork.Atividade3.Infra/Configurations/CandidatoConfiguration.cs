using LeanWork.Atividade3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeanWork.Atividade3.Infra.Configurations;

public class CandidatoConfiguration : IEntityTypeConfiguration<Candidato>
{
    public void Configure(EntityTypeBuilder<Candidato> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Vaga)
            .WithMany(e => e.Candidatos)
            .HasForeignKey(e => e.VagaId);

        builder.Property(e => e.Nome)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.TecnologiasConhecidas)
            .IsRequired();
    }
}
