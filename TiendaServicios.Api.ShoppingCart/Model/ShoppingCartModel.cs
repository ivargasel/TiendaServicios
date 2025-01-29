using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.Api.ShoppingCart.Model
{
    public class ShoppingCartModel
    {
        [Key, Required]
        public int ShoppingCartId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<ShoppingCartDetailModel> DetailsList { get; set; }
    }
}
