using AutoMapper;
using VendasBusiness.Interface.Repository;
using VendasBusiness.Interface.Services;
using VendasBusiness.Models;
using VendasBusiness.Notificacoes;
using VendasBusiness.ViewModel.Validator;
using VendasBusiness.ViewModel.Vendedor;

namespace VendasBusiness.Services
{
    public class VendedorService : BaseService, IVendedorService
    {
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IMapper _mapper;
        public VendedorService(INotificador notificador, 
                                  IVendedorRepository repository, 
                                  IMapper mapper) : base(notificador)
        {
            _vendedorRepository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DadosVendedorViewModel>> ObterTodos()
        {
            var result = await _vendedorRepository.ObterDadosGerais();
            if (result == null)
            {
                Notificar("Nenhum vendedor encontrado!");
                return null;
            }
            var vendedorDto = _mapper.Map<IEnumerable<DadosVendedorViewModel>>(result);
            return vendedorDto;
        }

        public async Task<DadosVendedorViewModel> ObterPorId(long id)
        {
            var result = await _vendedorRepository.SelectByQuery(p => p.Id == id);
            if(result is null)
            {
                Notificar("Vendedor não encontrado!");
                return null;
            }
            var vendedorDto = _mapper.Map<DadosVendedorViewModel>(result);
            return vendedorDto;
        }

        public async Task<DadosVendedorViewModel> Criar(CriarVendedorViewModel vendedor)
        {
            if(ExecutarValidacao(new CriarVendedorViewModelValidator(), vendedor) == false) return null;
            var entity = _mapper.Map<Vendedor>(vendedor);
            _vendedorRepository.Insert(entity);
            await _vendedorRepository.Commit();
            var dto = _mapper.Map<DadosVendedorViewModel>(entity);
            return dto;
        }
        public async Task<DadosVendedorViewModel> Atualizar(AtualizarVendedorViewModel vendedor)
        {
            if(ExecutarValidacao(new AtualizarVendedorViewModelValidator(),vendedor) == false) return null;
            var entity = await _vendedorRepository.SelectByQuery(p => p.Id == vendedor.Id);
            if(entity is null)
            {
                Notificar("Vendedor não encontrado!");
                return null;
            }
            entity.Nome = vendedor.Nome;
            _vendedorRepository.Update(entity);
            await _vendedorRepository.Commit();
            var vendedorDto = _mapper.Map<DadosVendedorViewModel>(entity);
            return vendedorDto;
        }

        public async Task<bool> Inativar(long id)
        {
            var entity = await _vendedorRepository.SelectByQuery(v => v.Id == id);
            if(entity is null)
            {
                Notificar("Vendedor não encontrado");
                return false;
            }
            entity.Ativo = false;
            _vendedorRepository.Update(entity);
            await _vendedorRepository.Commit();
            return true;
        }

     
    }
}
