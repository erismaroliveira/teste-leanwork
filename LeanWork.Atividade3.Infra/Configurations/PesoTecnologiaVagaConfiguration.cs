using LeanWork.Atividade3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeanWork.Atividade3.Infra.Configurations;

public class PesoTecnologiaVagaConfiguration : IEntityTypeConfiguration<PesoTecnologiaVaga>
{
    public void Configure(EntityTypeBuilder<PesoTecnologiaVaga> builder)
    {
        builder.HasKey(e => e.Id);

    }
}
