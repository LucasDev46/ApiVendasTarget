
using Microsoft.AspNetCore.Mvc;
using VendasBusiness.Notificacoes;

namespace VendasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : MainController
    {
        public ProdutoController(INotificador notificador) : base(notificador)
        {
        }
    }
}
