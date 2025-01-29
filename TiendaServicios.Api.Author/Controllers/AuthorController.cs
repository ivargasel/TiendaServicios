using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Author.Application;
using TiendaServicios.Api.Author.DTO;

namespace TiendaServicios.Api.Author.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AuthorController(IActionsApp mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<bool>> Create(BookAuthorDTO data)
        {
            return await mediator.Insert(data);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(BookAuthorDTO data)
        {
            return await mediator.Delete(data);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Edit(BookAuthorDTO data)
        {
            return await mediator.Edit(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookAuthorDTO>>> Index()
        {
            var data = await mediator.Index();
            return data;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookAuthorDTO>> Index(string id)
        {
            var data = await mediator.Index(id);
            return data;
        }
    }
}