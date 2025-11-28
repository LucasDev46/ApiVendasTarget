
namespace VendasBusiness.ViewModel.Produto
{
    public class DadosProdutoViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string descricaoProduto { get; set; }
        public int Estoque { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
    }

}
