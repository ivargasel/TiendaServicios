using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Book.Model;

namespace TiendaServicios.Api.Book.Persistence
{
    public class BookContext : DbContext
    {
        public BookContext() { }
        public BookContext(DbContextOptions<BookContext> options) : base(options) { } 
        public virtual DbSet<BookModel> Books { get; set; }
    }
}
