using AutoMapper;
using VendasBusiness.Models;
using VendasBusiness.ViewModel.Vendedor;

namespace VendasBusiness.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Vendedor, DadosVendedorViewModel>();
            CreateMap<Vendedor, CriarVendedorViewModel>().ReverseMap();
            CreateMap<Vendedor, AtualizarVendedorViewModel>().ReverseMap();
        }
    }
}
