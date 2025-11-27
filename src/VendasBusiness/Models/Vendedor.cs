
namespace VendasBusiness.Models
{
    public class Vendedor : Entity
    {
        public string Nome { get; set; }
        public decimal Comissao { get; set; }
        public ICollection<Venda> Vendas { get; set; } = new List<Venda>();
        public bool Ativo { get; set; } = true;
    }
}
