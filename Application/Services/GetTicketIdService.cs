using Application.IApplications.GetTicketId;
using Domain.IRepository;
using Infrastructure.Helper;

namespace Application.Services
{
    public class GetTicketIdService(LoginHelper loginHelper,IGetTicketId getTicketId) : IGetIdTicket
    {
        public async Task<int?> GetTicketIdAsync(string sessionToken, string fileName)
        {
            var today = DateTime.UtcNow.ToString("yyyy-MM-dd");

             string urlToGetIdSAP = "https://laboratoriotiaraju.verdanadesk.com/apirest.php/search/Ticket?criteria[0][field]=1&criteria[0][searchtype]=contains&criteria[0][value]=Backup Grupo Tiaraju (SAP) - Success&criteria[1][field]=12&criteria[1][searchtype]=equals&criteria[1][value]=1&forcedisplay[0]=1&forcedisplay[1]=12&forcedisplay[2]=15";
             string urlToGetIdServer = "https://laboratoriotiaraju.verdanadesk.com/apirest.php/search/Ticket?criteria[0][field]=1&criteria[0][searchtype]=contains&criteria[0][value]=Backup Grupo Tiaraju (SERVER1) - Success&criteria[1][field]=12&criteria[1][searchtype]=equals&criteria[1][value]=1&forcedisplay[0]=1&forcedisplay[1]=12&forcedisplay[2]=15";
            
           
             var token = await loginHelper.RealizarLogin();

             if (fileName == "Backup_SERVER")
            {
                return await getTicketId.GetTicketIdAsync(token.session_token, urlToGetIdServer);
            }
            //Código para o Servidor do SAP
            return await getTicketId.GetTicketIdAsync(token.session_token, urlToGetIdSAP);
        }
    }
}