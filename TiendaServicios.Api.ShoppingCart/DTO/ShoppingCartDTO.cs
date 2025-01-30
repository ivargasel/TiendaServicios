using TiendaServicios.Api.ShoppingCart.Application;

namespace TiendaServicios.Api.ShoppingCart.DTO
{
    public class ShoppingCartDTO
    {
        public int ShoppingCartId { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public ICollection<CartDetailDTO> DetailsList { get; set; }
        public List<string> Items { get; set; }
    }
}