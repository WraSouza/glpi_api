using Domain.Entities;

namespace Application.IApplications.GetAllDevices
{
    public interface IGetAllDevices
    {
        Task<IEnumerable<Device>> GetAllDevicesAsync();
    }
}
