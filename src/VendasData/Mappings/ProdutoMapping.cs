

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendasBusiness.Models;

namespace VendasData.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.descricaoProduto)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Preco)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(p => p.Estoque)
                .IsRequired()
                .HasColumnType("int");

            // RELACIONAMENTO 1:N COM VENDAS
            builder.HasMany(p => p.Vendas)     
                   .WithOne(v => v.Produto)        
                   .HasForeignKey(v => v.ProdutoId); 
                   
        }
    }
}
