using Domain.Entities;
using Domain.IRepository;
using Domain.ViewModel;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Infrastructure.Repository
{
    public class GetTicketId(IOptions<GLPILogin> option) : IGetTicketId
    { 
        public async Task<int?> GetTicketIdAsync(string sessionToken, string url)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.DefaultRequestHeaders.Add("App-Token", option.Value.AppToken);
                client.DefaultRequestHeaders.Add("Session-Token", sessionToken);

                var responseData = await client.GetAsync(url);

                if (!responseData.IsSuccessStatusCode)
                    return null;

                string datasFromGLPI = await responseData.Content.ReadAsStringAsync();
                TicketInfoViewModel? device = JsonConvert.DeserializeObject<TicketInfoViewModel>(datasFromGLPI);

                // 1. Definimos a janela de tempo
                var agora = DateTime.Now;
                var limiteMinimo = agora.AddHours(-12);

                // 2. Filtramos na lista
                var ticket = device?.data?
                    .OrderByDescending(t => t._2) // Garante que se houver dois recentes, pegamos o de maior ID
                    .FirstOrDefault(t =>
                    {
                        if (string.IsNullOrWhiteSpace(t._15)) return false;

                        // MUDANÇA CRÍTICA: Usar TryParse em vez de TryParseExact.
                        // O GLPI pode retornar "2026-04-25 01:03:00" ou "25-04-2026 01:03".
                        // O TryParse identifica ambos automaticamente.
                        if (!DateTime.TryParse(t._15, out DateTime dataAbertura))
                            return false;

                        // 3. Aplica a sua regra de negócio
                        // O ticket 5104 (24/04 23:39) entrará aqui se 'agora' for até 09:39 da manhã do dia 25.
                        return dataAbertura >= limiteMinimo && dataAbertura <= agora;
                    });

                return ticket?._2;
            }
        }
        
    }
}