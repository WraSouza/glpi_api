using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Domain.Entities;
using Domain.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repository
{
    public class UpdateTicketRepository(IOptions<GLPILogin> option) : IScreenShotRepository
    {
        public async Task<bool> SendScreenshotAsync(IFormFile file, int? ticketId,string ticketType, string contentTicket,string sessionToken)
        {
            string urlUpdateTicket = $"https://laboratoriotiaraju.verdanadesk.com/apirest.php/Ticket/{ticketId}/ITILFollowup";
            
             HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.DefaultRequestHeaders.Add("App-Token", option.Value.AppToken);
                client.DefaultRequestHeaders.Add("Session-Token", sessionToken);

                var manifest = new
                {
                    input = new
                    {
                        items_id = ticketId,
                        itemtype = ticketType,
                        content = contentTicket,
                        filename = new[] { file.FileName }
                    }
                };

                string manifestJson = JsonSerializer.Serialize(manifest);

                using var form = new MultipartFormDataContent();

                // adiciona o JSON
                form.Add(new StringContent(manifestJson, Encoding.UTF8, "application/json"), "uploadManifest");

                // adiciona o arquivo
                using var stream = file.OpenReadStream();
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                form.Add(fileContent, "fileName[]", file.FileName);

                var response = await client.PostAsync(urlUpdateTicket, form);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    // Log de falha ou tratamento de erro
                    return false;
                }

                return true;
            }
        }
    }
}