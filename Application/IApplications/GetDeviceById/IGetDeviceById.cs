using Domain.ViewModel;

namespace Application.IApplications.GetDeviceById
{
    public interface IGetDeviceById
    {
        Task<DeviceInfoViewModel> GetDeviceByIdAsync(int id);
    }
}
