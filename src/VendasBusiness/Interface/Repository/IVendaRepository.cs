
using VendasBusiness.Models;

namespace VendasBusiness.Interface.Repository
{
    public interface IVendaRepository : IRepository<Venda>
    {
        Task<Venda> ObterVendaComDetalhe(long id);
    }
}
