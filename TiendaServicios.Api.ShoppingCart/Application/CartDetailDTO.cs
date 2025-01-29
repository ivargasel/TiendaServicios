using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.Api.ShoppingCart.Application
{
    public class CartDetailDTO
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public DateTime PublisheddDate { get; set; }
        public Guid BookAuthorId { get; set; }
    }
}
