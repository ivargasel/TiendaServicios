using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Book.Application;
using TiendaServicios.Api.Book.DTO;

namespace TiendaServicios.Api.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IActionsApp action) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<bool>> Create(BookDTO request)
        {
            return await action.Create(request);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Edit(BookDTO request)
        {
            return await action.Edit(request);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(BookDTO request)
        {
            return await action.Delete(request);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> Index()
        {
            var data = await action.Index();
            return data;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> Index(Guid id)
        {
            var data = await action.Index(id);
            return data;
        }
    }
}