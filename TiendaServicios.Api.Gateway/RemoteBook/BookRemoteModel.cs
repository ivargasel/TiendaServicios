using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.Api.Gateway.RemoteBook
{
    public class BookRemoteModel
    {
        public Guid BookId { get; set; } = Guid.NewGuid();

        public string Title { get; set; }

        public DateTime PublishedDate { get; set; } = DateTime.Now;

        public Guid BookAuthorId { get; set; }

        public AuthorRemoteModel Author { get; set; }
    }
}