

using VendasBusiness.Interface.Repository;
using VendasBusiness.Models;
using VendasData.Context;

namespace VendasData.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(VendasAppContext context) : base(context)
        {
        }
    }
}
