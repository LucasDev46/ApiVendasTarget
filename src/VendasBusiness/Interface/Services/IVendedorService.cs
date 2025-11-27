using VendasBusiness.Models;
using VendasBusiness.ViewModel.Vendedor;

namespace VendasBusiness.Interface.Services
{
    public interface IVendedorService
    {
        Task<IEnumerable<DadosVendedorViewModel>> ObterTodos();
        Task<DadosVendedorViewModel> ObterPorId(long id);
        Task<DadosVendedorViewModel> Criar(CriarVendedorViewModel entity);
        Task<DadosVendedorViewModel> Atualizar(AtualizarVendedorViewModel entity);
        Task<bool> Inativar(long id);
    }
}
