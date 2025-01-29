using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.Api.Author.Model
{
    public class AcademyGradeModel
    {
        [Key]
        public int AcademyGradeId { get; set; }
        public string Name { get; set; }
        public string AcademyCenter { get; set; }
        public DateTime? GradeDate { get; set; }
        public Guid BookAuthorId { get; set; }
        public BookAuthorModel BookAuthor { get; set; }
        public string AcademyGradeGuid { get; set; }
    }
}