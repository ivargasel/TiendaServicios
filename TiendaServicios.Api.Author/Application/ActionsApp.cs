using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Author.DTO;
using TiendaServicios.Api.Author.Model;
using TiendaServicios.Api.Author.Persistence;

namespace TiendaServicios.Api.Author.Application
{
    public interface IActionsApp
    {
        Task<bool> Delete(BookAuthorDTO request);
        Task<bool> Edit(BookAuthorDTO request);
        Task<List<BookAuthorDTO>> Index();
        Task<BookAuthorDTO> Index(string id);
        Task<bool> Insert(BookAuthorDTO request);
    }

    public class ActionsApp(AuthorContext context, IMapper mapper) : IActionsApp
    {
        public async Task<bool> Delete(BookAuthorDTO request)
        {
            var data = mapper.Map<BookAuthorModel>(request);
            context.BookAuthor.Remove(data);
            var response = await context.SaveChangesAsync();

            if (response > 0)
                return true;

            throw new Exception("No se pudo eliminar el autor del libro");
        }

        public async Task<bool> Edit(BookAuthorDTO request)
        {
            var data = mapper.Map<BookAuthorModel>(request);
            context.BookAuthor.Update(data);
            var response = await context.SaveChangesAsync();

            if (response > 0)
                return true;

            throw new Exception("No se pudo actualizar el autor del libro");
        }
        public async Task<List<BookAuthorDTO>> Index()
        {
            var data = await context.BookAuthor.Select(x => mapper.Map<BookAuthorDTO>(x)).ToListAsync();
            return data;
        }

        public async Task<BookAuthorDTO> Index(string id)
        {
            var data = await context.BookAuthor.Where(x => x.BookAuthorGuid == id).Select(x => mapper.Map<BookAuthorDTO>(x)).SingleOrDefaultAsync();
            if (data != null)
                return data;

            throw new Exception("La información solicitada no existe en la base de datos.");
        }

        public async Task<bool> Insert(BookAuthorDTO request)
        {
            var data = mapper.Map<BookAuthorModel>(request);
            context.BookAuthor.Add(data);
            var response = await context.SaveChangesAsync();

            if (response > 0)
                return true;

            throw new Exception("No se pudo agregar el autor del libro");
        }
    }
}