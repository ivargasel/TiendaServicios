using System.Text.Json;
using TiendaServicios.Api.Gateway.RemoteBook;

namespace TiendaServicios.Api.Gateway.InterfaceRemote
{
    public interface IAuthorService
    {
        Task<(bool result, AuthorRemoteModel author, string errorMsg)> GetAuthorAsync(Guid id);
    }

    public class AuthorService (IHttpClientFactory httpClient, ILogger<AuthorService> logger) : IAuthorService
    {

        public async Task<(bool result, AuthorRemoteModel author, string errorMsg)> GetAuthorAsync(Guid id)
        {
            try
            {
                var client = httpClient.CreateClient("AuthorService");
                var response = await client.GetAsync($"/authors/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<AuthorRemoteModel>(content, options);
                                                
                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}