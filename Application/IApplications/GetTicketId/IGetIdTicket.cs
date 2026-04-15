
namespace Application.IApplications.GetTicketId
{
    public interface IGetIdTicket
    {
         Task<int?> GetTicketIdAsync(string sessionToken, string fileName);
    }
}