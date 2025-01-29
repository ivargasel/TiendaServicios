using System.Text.Json;
using TiendaServicios.Api.ShoppingCart.RemoteModel;

namespace TiendaServicios.Api.ShoppingCart.RemoteServices
{
    public interface IBooksService
    {
        Task<(bool result, BookRemoteModel Book, string error)> GetBook(Guid id);
    }

    public class BooksService (ILogger<BooksService> logger, IHttpClientFactory httpClient) : IBooksService
    {
        public async Task<(bool result, BookRemoteModel Book, string error)> GetBook(Guid id)
        {
            try
            {
                var client = httpClient.CreateClient("Books");
                var response = await client.GetAsync($"api/books/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<BookRemoteModel>(content, options);

                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
