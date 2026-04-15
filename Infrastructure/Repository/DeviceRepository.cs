using Domain.Entities;
using Domain.IRepository;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Infrastructure.Repository
{
    public class DeviceRepository(IOptions<GLPILogin> option) : IDeviceRepository
    {
        public async Task<IEnumerable<Device>> GetAllDevicesAsync(string sessionToken)
        {
            string url = "https://laboratoriotiaraju.verdanadesk.com/apirest.php/Computer?range=0-99";

            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.DefaultRequestHeaders.Add("App-Token", option.Value.AppToken);
                client.DefaultRequestHeaders.Add("Session-Token", sessionToken);

                var responseData = client.GetAsync(url);

                string datasFromGLPI = await responseData.Result.Content.ReadAsStringAsync();

               IEnumerable<Device>? device = JsonConvert.DeserializeObject<IEnumerable<Device>>(datasFromGLPI);

                return device;
            }
        }

        public async Task<List<DeviceInfo>> GetDeviceInfoAsync(int id, string sessionToken)
        {
            string url = $"https://laboratoriotiaraju.verdanadesk.com/apirest.php/Computer/{id}/Item_Disk";

            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                client.DefaultRequestHeaders.Add("App-Token", option.Value.AppToken);
                client.DefaultRequestHeaders.Add("Session-Token", sessionToken);

                var responseData = client.GetAsync(url);

                string datasFromGLPI = await responseData.Result.Content.ReadAsStringAsync();

                List<DeviceInfo>? device = JsonConvert.DeserializeObject<List<DeviceInfo>>(datasFromGLPI);

                return device.Where(x => x.mountpoint == "C:").ToList();
            }
        }
    }
}
