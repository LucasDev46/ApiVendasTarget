

using System.Runtime;

namespace VendasBusiness.ViewModel.Produto
{
    public class AtualizarEstoqueViewModel
    {
        public long CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int Estoque { get; set; }
    }
}
