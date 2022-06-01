using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Infrastructure.EntitiesConfiguration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
            builder.Property(c => c.ImagemUrl).HasMaxLength(100).IsRequired();

            builder.HasData(
              new Categoria(1, "Material Escolar", "material.jpg"),
              new Categoria(2, "Eletrônicos", "eletronicos.jpg"),
              new Categoria(3, "Acessórios", "acessorios.jpg")
            );
        }
    }
}
