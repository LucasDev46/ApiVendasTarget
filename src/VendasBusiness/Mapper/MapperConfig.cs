using AutoMapper;
using VendasBusiness.Models;
using VendasBusiness.ViewModel.Produto;
using VendasBusiness.ViewModel.Venda;
using VendasBusiness.ViewModel.Vendedor;

namespace VendasBusiness.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //Vendedor
            CreateMap<Vendedor, DadosVendedorViewModel>()
                .ForMember(v => v.Vendedor, opt => opt.MapFrom(src => src.Nome));
            CreateMap<Vendedor, ComissaoVendedorViewModel>();
            CreateMap<Vendedor, CriarVendedorViewModel>().ReverseMap();
            CreateMap<Vendedor, AtualizarVendedorViewModel>().ReverseMap();

            //Produto
            CreateMap<Produto, DadosProdutoViewModel>();
            CreateMap<Produto, AtualizarEstoqueViewModel>();
            CreateMap<Produto, AtualizarProdutoViewModel>().ReverseMap();
            CreateMap<Produto, CriarProdutoViewModel>().ReverseMap();

            //Venda
            CreateMap<Venda, DadosVendaViewModel>()
                .ForMember(v => v.NomeVendedor, opt => opt.MapFrom(src => src.Vendedor.Nome))
                .ForMember(v => v.NomeProduto, opt => opt.MapFrom(src => src.Produto.Nome));
            CreateMap<Venda, CriarVendaViewModel>().ReverseMap();
            CreateMap<Venda, AtualizarVendaViewModel>();
        }
    }
}
