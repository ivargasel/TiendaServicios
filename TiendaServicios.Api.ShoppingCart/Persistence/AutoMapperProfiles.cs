using AutoMapper;
using TiendaServicios.Api.ShoppingCart.DTO;
using TiendaServicios.Api.ShoppingCart.Model;

namespace TiendaServicios.Api.ShoppingCart.Persistence
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<ShoppingCartModel, ShoppingCartDTO>();
            CreateMap<ShoppingCartDTO, ShoppingCartModel>();

            CreateMap<ShoppingCartDetailModel, ShoppingCartDetailDTO>();
            CreateMap<ShoppingCartDetailDTO, ShoppingCartDetailModel>();
        }
    }
}
