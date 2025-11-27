

namespace VendasBusiness.Models
{
    public class Venda : Entity
    {
        public long VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        public long ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
