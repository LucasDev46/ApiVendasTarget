
using VendasBusiness.Models;

namespace VendasBusiness.Interface.Repository
{
    public interface IVendedorRepository : IRepository<Vendedor>
    {
        Task<IEnumerable<Vendedor>> ObterDadosGerais();
    }
}
