
using System.ComponentModel.DataAnnotations;

namespace VendasBusiness.ViewModel.Venda
{
    public class CriarVendaViewModel
    {
        [Required(ErrorMessage ="Nome Obrigatório!")]
        public string Nome { get; set; }

    }
}
