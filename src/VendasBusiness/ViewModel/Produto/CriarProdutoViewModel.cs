
using System.Text.Json.Serialization;

namespace VendasBusiness.ViewModel.Produto
{
    public class CriarProdutoViewModel
    {
        public string Nome { get; set; }
        public string descricaoProduto { get; set; }
        public int Estoque { get; set; }
        public decimal Preco { get; set; }
        [JsonIgnore]
        public bool Ativo { get; set; } = true;
    }
}
