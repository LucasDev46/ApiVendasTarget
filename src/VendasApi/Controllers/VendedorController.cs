
using Microsoft.AspNetCore.Mvc;
using VendasBusiness.Interface.Services;
using VendasBusiness.Notificacoes;
using VendasBusiness.ViewModel.Vendedor;

namespace VendasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : MainController
    {
        private readonly IVendedorService _vendedorService;
        public VendedorController(INotificador notificador, IVendedorService vendedorService) : base(notificador)
        {
            _vendedorService = vendedorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DadosVendedorViewModel>>> ObterTodosVendedor()
        {
            var result = await _vendedorService.ObterTodos();
            return CustomResponse(result);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<IEnumerable<DadosVendedorViewModel>>> ObterVendedorPorId(long id)
        {
            var result = await _vendedorService.ObterPorId(id);
            if (result == null) return CustomResponse();
            return CustomResponse(result);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<DadosVendedorViewModel>>> CriarVendedor(CriarVendedorViewModel vendedor)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _vendedorService.Criar(vendedor);
            if (result is null) return CustomResponse();

            return CustomResponse(result, 201);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<DadosVendedorViewModel>>> AtualizarVendedor(AtualizarVendedorViewModel vendedor)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _vendedorService.Atualizar(vendedor);
            if (result is null) return CustomResponse();

            return CustomResponse(result);
        }

        [HttpPatch("{id:long}")]
        public async Task<ActionResult<IEnumerable<DadosVendedorViewModel>>> InativarVendedor(long id)
        {
            var vendedor = await _vendedorService.Inativar(id);

            if(vendedor is false) return NotFound();

            return NoContent();
        }
    }
}
