using Microsoft.AspNetCore.Http;

namespace Application.IApplications.UpdateTicket
{
    public interface IUpdateTicket
    {
        Task<bool> SendScreenshotAsync(IFormFile file);
    }
}