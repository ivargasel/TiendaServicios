namespace TiendaServicios.Api.ShoppingCart.RemoteModel
{
    public class BookRemoteModel
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public DateTime PublisheddDate { get; set; }
        public Guid BookAuthorId { get; set; }
    }
}
