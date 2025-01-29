using System.ComponentModel.DataAnnotations;
using TiendaServicios.Api.ShoppingCart.Model;

namespace TiendaServicios.Api.ShoppingCart.DTO
{
    public class ShoppingCartDetailDTO
    {
        public int ShoppingCartDetailId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Product { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCartModel ShoppingCart { get; set; }
    }
}
