
using Microsoft.AspNetCore.Mvc;
using VendasBusiness.Notificacoes;

namespace VendasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : MainController
    {
        public VendaController(INotificador notificador) : base(notificador)
        {
        }
    }
}
