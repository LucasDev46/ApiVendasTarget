using AutoMapper;
using VendasBusiness.Models;
using VendasBusiness.ViewModel.Produto;
using VendasBusiness.ViewModel.Vendedor;

namespace VendasBusiness.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //Vendedor
            CreateMap<Vendedor, DadosVendedorViewModel>();
            CreateMap<Vendedor, CriarVendedorViewModel>().ReverseMap();
            CreateMap<Vendedor, AtualizarVendedorViewModel>().ReverseMap();

            //Produto
            CreateMap<Produto, DadosProdutoViewModel>();
            CreateMap<Produto, AtualizarProdutoViewModel>().ReverseMap();
            CreateMap<Produto, CriarProdutoViewModel>().ReverseMap();
        }
    }
}
