using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendasBusiness.Models;

namespace VendasData.Mappings
{
    public class VendedorMapping : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.Property(v => v.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(v => v.Comissao)
                .HasColumnType("decimal(8,2)");

            // RELACIONAMENTO 1:N
            builder.HasMany(v => v.Vendas)       // Um vendedor TEM MUITAS vendas
                   .WithOne(v => v.Vendedor)     // Cada venda TEM UM vendedor
                   .HasForeignKey(v => v.VendedorId);
        }
    }
}
