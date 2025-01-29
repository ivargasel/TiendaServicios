﻿using AutoMapper;
using TiendaServicios.Api.Book.DTO;
using TiendaServicios.Api.Book.Model;

namespace TiendaServicios.Api.Book.Tests
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<BookModel, BookDTO>();
            CreateMap<BookDTO, BookModel>();
        }
    }
}
