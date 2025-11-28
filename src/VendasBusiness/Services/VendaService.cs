

using AutoMapper;
using VendasBusiness.Interface.Repository;
using VendasBusiness.Interface.Services;
using VendasBusiness.Models;
using VendasBusiness.Notificacoes;
using VendasBusiness.ViewModel.Validator;
using VendasBusiness.ViewModel.Venda;

namespace VendasBusiness.Services
{
    public class VendaService : BaseService, IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public VendaService(INotificador notificador, 
                            IVendaRepository vendaRepository, 
                            IVendedorRepository vendedorRepository, 
                            IProdutoRepository produtoRepository, 
                            IMapper mapper) : base(notificador)
        {
            _vendaRepository = vendaRepository;
            _vendedorRepository = vendedorRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<DadosVendaViewModel> ObterPorId(long id)
        {
            var result = await _vendaRepository.ObterVendaComDetalhe(id);
            if(result == null)
            {
                Notificar("Venda não encontrada!");
                return null;
            }
            var dto = _mapper.Map<DadosVendaViewModel>(result);
            return dto;
        }

        public async Task<IEnumerable<DadosVendaViewModel>> ObterTodos()
        {
            var result = await _vendaRepository.SelectAll();
            var dto = _mapper.Map<IEnumerable<DadosVendaViewModel>>(result);
            return dto;
        }
   

        public async Task<DadosVendaViewModel> Criar(CriarVendaViewModel venda)
        {
            if(ExecutarValidacao(new CriarVendaViewModelValidator(), venda) == false) return null;

            var vendedor = await _vendedorRepository.SelectByQuery(v => v.Id == venda.VendedorId);
            if (vendedor == null)
            {
                Notificar("Vendedor não encontrado!");
            }

            var produto = await _produtoRepository.SelectByQuery(p => p.Id == venda.ProdutoId);
            if (produto == null)
            {
                Notificar("Produto não encontrado!");
            }
            if(produto.Estoque < venda.Quantidade)
            {
                Notificar("Produto sem estoque suficiente!");
                return null;
            }
            produto.Estoque -= venda.Quantidade;
            var totalVenda = produto.Preco * venda.Quantidade;

            var entity = _mapper.Map<Venda>(venda);
            entity.ValorTotal = totalVenda;

            vendedor.Vendas.Add(entity);

            if(totalVenda < 500 && totalVenda >= 100)
            {

                vendedor.Comissao += totalVenda * 0.01m;
            }
            if(totalVenda >= 500)
            {
                vendedor.Comissao += totalVenda * 0.05m;
            }

            try
            {
                _produtoRepository.Update(produto);
                _vendedorRepository.Update(vendedor);
                _vendaRepository.Insert(entity);
                await _vendaRepository.Commit();
            } catch (Exception ex)
            {
                Notificar(ex.Message);
            }
           

            var dto = _mapper.Map<DadosVendaViewModel>(entity);
            return dto;
        }
        public Task<DadosVendaViewModel> Atualizar(CriarVendaViewModel venda)
        {
            throw new NotImplementedException();
        }
    }
}
