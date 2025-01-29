using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Author.Model;

namespace TiendaServicios.Api.Author.Persistence
{
    public class AuthorContext(DbContextOptions<AuthorContext> options) : DbContext(options)
    {
        public DbSet<BookAuthorModel> BookAuthor { get; set; }
        public DbSet<AcademyGradeModel> AcademyGrade { get; set; }
    }
}
