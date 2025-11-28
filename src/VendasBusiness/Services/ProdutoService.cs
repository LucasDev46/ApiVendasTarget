
using AutoMapper;
using VendasBusiness.Interface.Repository;
using VendasBusiness.Interface.Services;
using VendasBusiness.Models;
using VendasBusiness.Notificacoes;
using VendasBusiness.ViewModel.Produto;
using VendasBusiness.ViewModel.Validator;

namespace VendasBusiness.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public ProdutoService(INotificador notificador, IProdutoRepository produtoRepository, IMapper mapper) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<DadosProdutoViewModel> ObterPorId(long id)
        {
            var result = await _produtoRepository.SelectByQuery(p => p.Id == id);
            if (result is null)
            {
                Notificar("Produto não encontrado!");
                return null;
            }
            var produtoDto = _mapper.Map<DadosProdutoViewModel>(result);
            return produtoDto;
        }

        public async Task<IEnumerable<DadosProdutoViewModel>> ObterTodos()
        {
            var result = await _produtoRepository.SelectAll();
            if (result == null)
            {
                Notificar("Nenhum produto encontrado!");
                return null;
            }
            var produtoDto = _mapper.Map<IEnumerable<DadosProdutoViewModel>>(result);
            return produtoDto;
        }

        public async Task<DadosProdutoViewModel> Atualizar(AtualizarProdutoViewModel produto)
        {
            if (ExecutarValidacao(new AtualizarProdutoViewModelValidator(), produto) == false) return null;
            var entity = await _produtoRepository.SelectByQuery(p => p.Id == produto.Id);
            if (entity is null)
            {
                Notificar("Produto não encontrado!");
                return null;
            }
            entity.Nome = produto.Nome;
            entity.Preco = produto.Preco;
            entity.descricaoProduto = produto.descricaoProduto;
            entity.Estoque = produto.Estoque;

            _produtoRepository.Update(entity);
            await _produtoRepository.Commit();
            var produtoDto = _mapper.Map<DadosProdutoViewModel>(entity);
            return produtoDto;
        }

        public async Task<DadosProdutoViewModel> AdicionarEstoque(AtualizarEstoqueViewModel produto)
        {
            if (ExecutarValidacao(new AtualizarEstoqueValidator(), produto) == false) return null;
            var entity = await VerificarProduto(produto.CodigoProduto);
            if (entity == null)
            {
                Notificar("Produto Não encontrado!");
                return null;
            }
            entity.Estoque += produto.Estoque;
            entity.descricaoProduto = produto.DescricaoProduto;
            _produtoRepository.Update(entity);
            await _produtoRepository.Commit();
            var dto = _mapper.Map<DadosProdutoViewModel>(entity);
            return dto;
        }

        public async Task<DadosProdutoViewModel> RetirarEstoque(AtualizarEstoqueViewModel produto)
        {
            if (ExecutarValidacao(new AtualizarEstoqueValidator(), produto) == false) return null;
            var entity = await VerificarProduto(produto.CodigoProduto);
            if (entity == null)
            {
                Notificar("Produto Não encontrado!");
                return null;
            }
            entity.Estoque -= produto.Estoque;
            entity.descricaoProduto = produto.DescricaoProduto;
            _produtoRepository.Update(entity);
            await _produtoRepository.Commit();
            var dto = _mapper.Map<DadosProdutoViewModel>(entity);
            return dto;
        }

        public async Task<DadosProdutoViewModel> Criar(CriarProdutoViewModel produto)
        {
            if (ExecutarValidacao(new CriarProdutoViewModelValidator(), produto) == false) return null;

            if(await _produtoRepository.SelectByQuery(p => p.Nome == produto.Nome) != null){
                Notificar("Produto com o mesmo nome ja cadastrado!");
                return null;
            }
            var entity = _mapper.Map<Produto>(produto);

            _produtoRepository.Insert(entity);
            await _produtoRepository.Commit();

            var dto = _mapper.Map<DadosProdutoViewModel>(entity);
            return dto;
        }

        public async Task<bool> Inativar(long id)
        {
            var entity = await _produtoRepository.SelectByQuery(v => v.Id == id);
            if (entity is null)
            {
                Notificar("Produto não encontrado");
                return false;
            }
            entity.Ativo = false;
            _produtoRepository.Update(entity);
            await _produtoRepository.Commit();
            return true;
        }

        private async Task<Produto> VerificarProduto(long id)
        {
            var entity = await _produtoRepository.SelectByQuery(p => p.Id == id);
            if (entity == null && entity.Id != id) return null;
            
            return entity;
        }
    }
}
