
using Microsoft.AspNetCore.Mvc;
using VendasBusiness.Interface.Services;
using VendasBusiness.Notificacoes;
using VendasBusiness.ViewModel.Produto;

namespace VendasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : MainController
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(INotificador notificador, IProdutoService produtoService) : base(notificador)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DadosProdutoViewModel>>> ObterTodosVendedor()
        {
            var result = await _produtoService.ObterTodos();
            return CustomResponse(result);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<IEnumerable<DadosProdutoViewModel>>> ObterVendedorPorId(long id)
        {
            var result = await _produtoService.ObterPorId(id);
            if (result == null) return CustomResponse();
            return CustomResponse(result);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<DadosProdutoViewModel>>> CriarVendedor(CriarProdutoViewModel produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _produtoService.Criar(produto);
            if (result is null) return CustomResponse();

            return CustomResponse(result, 201);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<DadosProdutoViewModel>>> AtualizarVendedor(AtualizarProdutoViewModel produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _produtoService.Atualizar(produto);
            if (result is null) return CustomResponse();

            return CustomResponse(result);
        }

        [HttpPatch("{id:long}")]
        public async Task<ActionResult<IEnumerable<DadosProdutoViewModel>>> InativarVendedor(long id)
        {
            var vendedor = await _produtoService.Inativar(id);

            if (vendedor is false) return NotFound();

            return NoContent();
        }
    }
}
