
using VendasBusiness.ViewModel.Produto;

namespace VendasBusiness.Interface.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<DadosProdutoViewModel>> ObterTodos();
        Task<DadosProdutoViewModel> ObterPorId(long id);
        Task<DadosProdutoViewModel> Criar(CriarProdutoViewModel produto);
        Task<DadosProdutoViewModel> Atualizar(AtualizarProdutoViewModel produto);
        Task<DadosProdutoViewModel> AdicionarEstoque(AtualizarEstoqueViewModel produto);
        Task<DadosProdutoViewModel> RetirarEstoque(AtualizarEstoqueViewModel produto);
        Task<bool> Inativar(long id);
    }
}
