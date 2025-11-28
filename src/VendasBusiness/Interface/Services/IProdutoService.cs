

using VendasBusiness.ViewModel.Produto;
using VendasBusiness.ViewModel.Vendedor;

namespace VendasBusiness.Interface.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<DadosProdutoViewModel>> ObterTodos();
        Task<DadosProdutoViewModel> ObterPorId(long id);
        Task<DadosProdutoViewModel> Criar(CriarProdutoViewModel produto);
        Task<DadosProdutoViewModel> Atualizar(AtualizarProdutoViewModel produto);
        Task<bool> Inativar(long id);
    }
}
