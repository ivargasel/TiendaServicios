using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.Api.Book.DTO
{
    public class BookDTO
    {
        public Guid BookId { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "El campo 'Titulo' es requerido")]
        public string Title { get; set; }
        
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        
        public Guid BookAuthorId { get; set; }
    }
}
