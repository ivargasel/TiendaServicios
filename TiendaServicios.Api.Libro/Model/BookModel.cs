using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.Api.Book.Model
{
    public class BookModel
    {
        [Key, Required]
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public DateTime PublisheddDate { get; set; }
        public Guid BookAuthorId { get; set; }
    }
}
