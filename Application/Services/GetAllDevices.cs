using Application.IApplications.GetAllDevices;
using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Helper;

namespace Application.Services
{
    public class GetAllDevices(IDeviceRepository repository, LoginHelper loginHelper) : IGetAllDevices
    {
        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            var token = await loginHelper.RealizarLogin();

            return await repository.GetAllDevicesAsync(token.session_token);
        }
    }
}
