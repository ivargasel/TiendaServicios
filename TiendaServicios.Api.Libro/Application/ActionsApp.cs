using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Book.DTO;
using TiendaServicios.Api.Book.Model;
using TiendaServicios.Api.Book.Persistence;

namespace TiendaServicios.Api.Book.Application
{
    public interface IActionsApp
    {
        Task<bool> Create(BookDTO request);
        Task<bool> Delete(BookDTO request);
        Task<bool> Edit(BookDTO request);
        Task<List<BookDTO>> Index();
        Task<BookDTO> Index(Guid id);
        Task<BookModel> IndexTest(Guid id);
        Task<List<BookModel>> Test();
    }

    public class ActionsApp (BookContext context, IMapper mapper) : IActionsApp
    {
        public async Task<bool> Create(BookDTO request)
        {
            var data = mapper.Map<BookModel>(request);
            context.Books.Add(data);
            var response = await context.SaveChangesAsync();

            if (response > 0)
                return true;

            throw new Exception("No se pudo guardar la información");
        }

        public async Task<bool> Delete(BookDTO request)
        {
            var data = mapper.Map<BookModel>(request);
            context.Books.Remove(data);
            var response = await context.SaveChangesAsync();

            if (response > 0)
                return true;

            throw new Exception("No se pudo eliminar la información");
        }

        public async Task<bool> Edit(BookDTO request)
        {
            var data = mapper.Map<BookModel>(request);
            context.Books.Update(data);
            var response = await context.SaveChangesAsync();

            if (response > 0)
                return true;

            throw new Exception("No se pudo actualizar la información");
        }

        public async Task<List<BookModel>> Test()
        {
            var data = await context.Books.ToListAsync();
            if (data.Count > 0)
                return data;

            throw new Exception("Error para traer la información");
        }

        public async Task<List<BookDTO>> Index()
        {
            var data = await context.Books.Select(x => mapper.Map<BookDTO>(x)).ToListAsync();                           
            return data;

            throw new Exception("Error para traer la información");
        }

        public async Task<BookDTO> Index(Guid id)
        {
            var data = await context.Books.Where(x => x.BookId == id).Select(x => mapper.Map<BookDTO>(x)).SingleOrDefaultAsync();
            if (data != null)
                return data;

            throw new Exception("Error para traer la información");
        }

        public async Task<BookModel> IndexTest(Guid id)
        {
            var data = await context.Books.Where(x => x.BookId == id).SingleOrDefaultAsync();
            if (data != null)
                return data;

            throw new Exception("Error para traer la información");
        }
    }
}
