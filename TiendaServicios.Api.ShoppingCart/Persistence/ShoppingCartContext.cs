using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.ShoppingCart.Model;

namespace TiendaServicios.Api.ShoppingCart.Persistence
{
    public class ShoppingCartContext (DbContextOptions options) : DbContext(options)
    {
        public DbSet<ShoppingCartModel> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartDetailModel> ShoppingCartDetails { get; set; }
    }
}
