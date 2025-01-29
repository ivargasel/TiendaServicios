using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.Api.Author.Model
{
    public class BookAuthorModel
    {
        [Key]
        public int BookAuthorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BookAuthorGuid { get; set; }
        public ICollection<AcademyGradeModel> AcademyGradesList { get; set; }        
    }
}