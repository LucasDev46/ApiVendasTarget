
using Microsoft.AspNetCore.Mvc;
using VendasBusiness.Interface.Services;
using VendasBusiness.Notificacoes;
using VendasBusiness.ViewModel.Venda;

namespace VendasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : MainController
    {
        private readonly IVendaService _vendaService;
        public VendaController(INotificador notificador, IVendaService vendaService) : base(notificador)
        {
            _vendaService = vendaService;
        }


        [HttpGet("Obter-Por-Id")]
        public async Task<ActionResult<DadosVendaViewModel>> ObterPorId(long id)
        {
            var result = await _vendaService.ObterPorId(id);
            if(result == null) return NotFound();

            return CustomResponse(result);
        }

        [HttpGet("Obter-Todos")]
        public async Task<ActionResult<IEnumerable<DadosVendaViewModel>>> ObterTodasVendas()
        {
            var result = await _vendaService.ObterTodos();
            return CustomResponse(result);
        }

        [HttpPost("Criar-Venda")]
        public async Task<ActionResult<DadosVendaViewModel>> CriarVenda(CriarVendaViewModel venda)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _vendaService.Criar(venda);
            return CustomResponse(result);
        }
    }
}
