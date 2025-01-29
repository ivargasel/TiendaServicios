using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.Api.Author.DTO
{
    public class BookAuthorDTO
    {        
        public int BookAuthorId { get; set; }

        [Required(ErrorMessage = "El campo 'Nombre' es requerido")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "El campo 'Apellido' es requerido")]
        public string LastName { get; set; }
        
        public DateTime? BirthDate { get; set; }
        
        public string BookAuthorGuid { get; set; } = Guid.NewGuid().ToString();
    }
}
