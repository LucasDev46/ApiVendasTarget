
using Microsoft.EntityFrameworkCore;
using VendasBusiness.Interface.Repository;
using VendasBusiness.Models;
using VendasData.Context;

namespace VendasData.Repository
{
    public class VendedorRepository : Repository<Vendedor>, IVendedorRepository
    {
        public VendedorRepository(VendasAppContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Vendedor>> ObterDadosGerais()
        {
            return await _dbSet.Include(v => v.Vendas)
                               .ToListAsync();
        }
        public async Task<Vendedor> ObterDadosPorId(long id)
        {
            return await _dbSet.Include(v => v.Vendas)
                               .FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
