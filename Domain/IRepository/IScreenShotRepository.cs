
using Microsoft.AspNetCore.Http;

namespace Domain.IRepository
{
    public interface IScreenShotRepository
    {
        Task<bool> SendScreenshotAsync(IFormFile file,int? ticketId,string ticketType, string contentTicket,string sessionToken);
    }
}