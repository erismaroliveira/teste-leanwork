using LeanWork.Atividade3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeanWork.Atividade3.Infra.Configurations;

public class TecnologiaConfiguration : IEntityTypeConfiguration<Tecnologia>
{
    public void Configure(EntityTypeBuilder<Tecnologia> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Nome)
            .HasMaxLength(50)
            .IsRequired();
    }
}
