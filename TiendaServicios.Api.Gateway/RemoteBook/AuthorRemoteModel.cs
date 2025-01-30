using System.ComponentModel.DataAnnotations;

namespace TiendaServicios.Api.Gateway.RemoteBook
{
    public class AuthorRemoteModel
    {
        public int BookAuthorId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string BookAuthorGuid { get; set; }
    }
}
