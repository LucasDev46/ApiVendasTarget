

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendasBusiness.Models;

namespace VendasData.Mappings
{
    public class VendaMapping : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.Property(v => v.Quantidade)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(v => v.ProdutoId)
                .IsRequired();

            builder.Property(v => v.VendedorId)
               .IsRequired();

            builder.Property(v => v.ValorTotal)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            //Relacionamentos
            builder.HasOne(v => v.Produto)
            .WithMany(p => p.Vendas)
            .HasForeignKey(v => v.ProdutoId);

            builder.HasOne(v => v.Vendedor)
                .WithMany(vd => vd.Vendas)
                .HasForeignKey(v => v.VendedorId);
        }
    }
}
