using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


namespace Infrastructure.Helper
{
    public class LoginHelper(IMemoryCache memoryCache, IOptions<GLPILogin> option)
    {

        private readonly string LOGIN_TOKEN = "GLPIToken";
        private string responseBody = string.Empty;

        public async Task<GLPIResponse> RealizarLogin()
        {
            if (memoryCache.TryGetValue(LOGIN_TOKEN, out GLPIResponse? tokenGLPI))
            {
                if (tokenGLPI is not null)
                    return tokenGLPI;
            }

           GLPIResponse? newResponse = new("");

            HttpClientHandler clientHandler = new()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            using (var client = new HttpClient(clientHandler))
            {
                client.DefaultRequestHeaders.Add("App-Token", option.Value.AppToken);
                client.DefaultRequestHeaders.Add("Authorization", option.Value.Authorization);

                HttpResponseMessage response = await client.GetAsync("https://laboratoriotiaraju.verdanadesk.com/apirest.php/initSession");

                responseBody = await response.Content.ReadAsStringAsync();

                newResponse = JsonConvert.DeserializeObject<GLPIResponse>(responseBody);
            }

            var memoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1800),
                SlidingExpiration = TimeSpan.FromSeconds(1500)
            };

            memoryCache.Set(LOGIN_TOKEN, newResponse, memoryCacheEntryOptions);

            return newResponse;
        }
    }
}
