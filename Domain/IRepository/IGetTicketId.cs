
namespace Domain.IRepository
{
    public interface IGetTicketId
    {
        Task<int?> GetTicketIdAsync(string sessionToken,string url);        
    }
}