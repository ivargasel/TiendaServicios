using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.Api.ShoppingCart.Model
{
    public class ShoppingCartDetailModel
    {
        [Key, Required]
        public int ShoppingCartDetailId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Product {  get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCartModel ShoppingCart { get; set; }
    }
}
