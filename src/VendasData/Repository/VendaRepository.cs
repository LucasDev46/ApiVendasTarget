

using Microsoft.EntityFrameworkCore;
using VendasBusiness.Interface.Repository;
using VendasBusiness.Models;
using VendasData.Context;

namespace VendasData.Repository
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(VendasAppContext context) : base(context)
        {
        }

        public async Task<Venda> ObterVendaComDetalhe(long id)
        {
            return await _dbSet.AsNoTracking()
                               .Include(v => v.Vendedor)
                               .Include(v => v.Produto)
                               .FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
