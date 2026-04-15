using Domain.Entities;
using Domain.IRepository;
using Domain.ViewModel;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Infrastructure.Repository
{
    public class GetTicketId(IOptions<GLPILogin> option) : IGetTicketId
    {        
        public async Task<int?> GetTicketIdAsync(string sessionToken,string url)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.DefaultRequestHeaders.Add("App-Token", option.Value.AppToken);
                client.DefaultRequestHeaders.Add("Session-Token", sessionToken);

                var responseData = await client.GetAsync(url);

                if (!responseData.IsSuccessStatusCode)
                {                   
                    return null;
                }

                string datasFromGLPI = await responseData.Content.ReadAsStringAsync();

                 TicketInfoViewModel? device = JsonConvert.DeserializeObject<TicketInfoViewModel>(datasFromGLPI);

                 var ticket = device?.data?.FirstOrDefault();

                 return ticket?._2;
                
            }
        }
    }
}