using VendasBusiness.ViewModel.Venda;

namespace VendasBusiness.ViewModel.Vendedor
{
    public class DadosVendedorViewModel
    {
        public long Id { get; set; }
        public string Vendedor { get; set; }
        public decimal Comissao { get; set; }

        public ICollection<DadosVendaViewModel> Vendas { get; set; } = new List<DadosVendaViewModel>();
    }
}
