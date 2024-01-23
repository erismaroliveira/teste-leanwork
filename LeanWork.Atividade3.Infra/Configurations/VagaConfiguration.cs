using LeanWork.Atividade3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeanWork.Atividade3.Infra.Configurations;

public class VagaConfiguration : IEntityTypeConfiguration<Vaga>
{
    public void Configure(EntityTypeBuilder<Vaga> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Titulo)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(e => e.DataCadastro)
                .IsRequired();

        builder.Property(e => e.DataAtualizacao)
            .IsRequired();

        builder.Property(e => e.Ativo)
                .IsRequired();
    }
}
