
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

        [HttpGet("Obter-Todos")]
        public async Task<ActionResult<IEnumerable<DadosProdutoViewModel>>> ObterTodosProduto()
        {
            var result = await _produtoService.ObterTodos();
            return CustomResponse(result);
        }

        [HttpGet("Obter-Por-Id/{id:long}")]
        public async Task<ActionResult<IEnumerable<DadosProdutoViewModel>>> ObterProdutoPorId(long id)
        {
            var result = await _produtoService.ObterPorId(id);
            if (result == null) return CustomResponse();
            return CustomResponse(result);
        }

        [HttpPost("Criar-Produto")]
        public async Task<ActionResult<IEnumerable<DadosProdutoViewModel>>> CriarProduto(CriarProdutoViewModel produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _produtoService.Criar(produto);
            if (result is null) return CustomResponse();

            return CustomResponse(result, 201);
        }
        [HttpPut("Adicionar-Estoque")]
        public async Task<ActionResult<DadosProdutoViewModel>> AdicionarEstoque(AtualizarEstoqueViewModel produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var result = await _produtoService.AdicionarEstoque(produto);
           
            if (result is null) return CustomResponse();

            return CustomResponse(result);
        }
        [HttpPut("Retirar-Estoque")]
        public async Task<ActionResult<DadosProdutoViewModel>> RetirarEstoque(AtualizarEstoqueViewModel produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var result = await _produtoService.RetirarEstoque(produto);

            if (result is null) return CustomResponse();

            return CustomResponse(result);
        }

        [HttpPut("Atualizar-Produto/{id:long}")]
        public async Task<ActionResult<IEnumerable<DadosProdutoViewModel>>> AtualizarProduto(AtualizarProdutoViewModel produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _produtoService.Atualizar(produto);
            if (result is null) return CustomResponse();

            return CustomResponse(result);
        }

        [HttpPatch("Inativar-Produto/{id:long}")]
        public async Task<ActionResult<IEnumerable<DadosProdutoViewModel>>> InativarProduto(long id)
        {
            var vendedor = await _produtoService.Inativar(id);

            if (vendedor is false) return NotFound();

            return NoContent();
        }
    }
}
