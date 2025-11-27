
namespace VendasBusiness.Models
{
    public class Produto : Entity
    {
        public string descricaoProduto { get; set; }
        public int Estoque { get; set; }
        public decimal Preco { get; set; }
        public ICollection<Venda> Vendas { get; set; } = new List<Venda>();
        public bool Ativo { get; set; } = true;
    }
}
