﻿using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Infrastructure.EntitiesConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(200).IsRequired();

            builder.Property(p => p.Preco).HasPrecision(10, 2);
            builder.Property(p => p.ImagemUrl).HasMaxLength(250);
            builder.Property(p => p.Estoque).HasDefaultValue(1).IsRequired();
            builder.Property(p => p.DataCadastro).IsRequired();

            builder.HasOne(p => p.Categoria).WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId);
        }
    }
}
