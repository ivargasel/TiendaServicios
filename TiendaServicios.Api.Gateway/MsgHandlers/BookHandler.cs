using System.Diagnostics;
using System.Text.Json;
using TiendaServicios.Api.Gateway.InterfaceRemote;
using TiendaServicios.Api.Gateway.RemoteBook;

namespace TiendaServicios.Api.Gateway.MsgHandlers
{
    public class BookHandler (ILogger<BookHandler> logger, IAuthorService authorService) : DelegatingHandler
    {       
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var time = Stopwatch.StartNew();
            logger.LogInformation("Inicia el Request");
            var response = await base.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<BookRemoteModel>(content, options);

                var responseAuthor = await authorService.GetAuthorAsync(result.BookAuthorId);

                if (responseAuthor.result)
                {
                    var objAuthor = responseAuthor.author;
                    result.Author = objAuthor;

                    var resulStr = JsonSerializer.Serialize(result);
                    response.Content = new StringContent(resulStr, System.Text.Encoding.UTF8, "application/json");
                }


            }

            logger.LogInformation($"Este proceso se hizo {time.ElapsedMilliseconds} ms");
            return response;
        }
    }
}