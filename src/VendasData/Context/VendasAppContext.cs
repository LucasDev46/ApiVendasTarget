
using Microsoft.EntityFrameworkCore;
using VendasBusiness.Models;

namespace VendasData.Context
{
    public class VendasAppContext : DbContext
    {
        public VendasAppContext(DbContextOptions<VendasAppContext> options) : base(options)
        {   
        }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendasAppContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
