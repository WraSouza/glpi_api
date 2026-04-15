using Application.IApplications.GetDeviceById;
using Domain.IRepository;
using Domain.ViewModel;
using Infrastructure.Helper;

namespace Application.Services
{
    public class GetDeviceById(IDeviceRepository repository, LoginHelper loginHelper) : IGetDeviceById
    {
        public async Task<DeviceInfoViewModel> GetDeviceByIdAsync(int id)
        {
            var token = await loginHelper.RealizarLogin();

            DeviceInfoViewModel deviceInfo = new();

            if(id <= 0)
            {
                throw new ArgumentException("ID inválido.");
            }

            var resultInfo = await repository.GetDeviceInfoAsync(id, token.session_token);

            if (resultInfo == null || !resultInfo.Any())
            {
                // Nenhum resultado encontrado, passa para o próximo id
                return null;
            }

            deviceInfo = new(resultInfo[0].totalsize, resultInfo[0].freesize);                       

            return deviceInfo;
        }
    }
}
