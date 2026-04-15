using Domain.Entities;

namespace Domain.IRepository
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetAllDevicesAsync(string sessionToken);
        Task<List<DeviceInfo>> GetDeviceInfoAsync(int id, string sessionToken);
    }
}
