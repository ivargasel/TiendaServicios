using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.ShoppingCart.Application;
using TiendaServicios.Api.ShoppingCart.DTO;

namespace TiendaServicios.Api.ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController(IActionsApp actions) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<bool>> Create(ShoppingCartDTO request)
        {
            return await actions.Create(request);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCartDTO>> Index(int id)
        {
            return await actions.Index(id);
        }
    }
}