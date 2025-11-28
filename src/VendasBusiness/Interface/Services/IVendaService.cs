
using VendasBusiness.Notificacoes;
using VendasBusiness.Services;
using VendasBusiness.ViewModel.Produto;
using VendasBusiness.ViewModel.Venda;

namespace VendasBusiness.Interface.Services
{
    public interface IVendaService 
    {
        Task<IEnumerable<DadosVendaViewModel>> ObterTodos();
        Task<DadosVendaViewModel> ObterPorId(long id);
        Task<DadosVendaViewModel> Criar(CriarVendaViewModel venda);
        Task<DadosVendaViewModel> Atualizar(CriarVendaViewModel venda);
    }
}
