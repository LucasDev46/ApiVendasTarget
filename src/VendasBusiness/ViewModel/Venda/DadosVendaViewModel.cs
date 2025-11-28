
namespace VendasBusiness.ViewModel.Venda
{
    public class DadosVendaViewModel
    {
        public long Id { get; set; }
        public long VendedorId { get; set; }
        public string NomeVendedor { get; set; }
        public long ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
