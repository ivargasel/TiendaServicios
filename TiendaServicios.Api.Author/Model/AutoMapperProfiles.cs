using AutoMapper;
using TiendaServicios.Api.Author.DTO;

namespace TiendaServicios.Api.Author.Model
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<BookAuthorModel, BookAuthorDTO>();
            CreateMap<BookAuthorDTO, BookAuthorModel>();
        }
    }
}
