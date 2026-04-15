using Application.IApplications.GetTicketId;
using Application.IApplications.UpdateTicket;
using Domain.IRepository;
using Infrastructure.Helper;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class UpdateTicketService(LoginHelper loginHelper,IGetIdTicket getTicketId, IScreenShotRepository screenShotRepository) : IUpdateTicket
    {
        public async Task<bool> SendScreenshotAsync(IFormFile file)
        {
            int? ticketId = 0;
            string ticketType = "Ticket";
            string content = "Backup do Servidor em Nuvem Realizado Com Sucesso";

            string fileName = file.FileName; 

            // encontra o último "_"
            int lastUnderscore = fileName.LastIndexOf("_");

            // encontra o penúltimo "_", procurando antes do último
            int secondLastUnderscore = fileName.LastIndexOf("_", lastUnderscore - 1);

            // corta a string até o penúltimo "_"
            string newFileName = fileName.Substring(0, secondLastUnderscore);
           
            var token = await loginHelper.RealizarLogin();            
            
           ticketId = await getTicketId.GetTicketIdAsync(token.session_token, newFileName);  

           if(ticketId == null)
            {
                return false;
            }

           var result = await screenShotRepository.SendScreenshotAsync(file,ticketId,ticketType,content,token.session_token);

            if(!result)
            {                        
                return false;
            }

            return result;   
        }
    }
}