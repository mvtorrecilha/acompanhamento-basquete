using AcompanhamentoBasquete.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcompanhamentoBasquete.Infra.Data.SQL.Configurations;

public class ConfiguracaoJogo : IEntityTypeConfiguration<Jogo>
{
    public void Configure(EntityTypeBuilder<Jogo> builder)
    {
        builder.ToTable("Jogos");

        builder.HasKey(j => j.Id);

        builder.Property(j => j.Data)
            .IsRequired()
            .HasColumnType("datetime2");

        builder.Property(j => j.Pontos)
            .IsRequired();
    }
}