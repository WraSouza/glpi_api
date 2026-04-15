using Application.IApplications.UpdateTicket;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
   [ApiController]
    [Route("[controller]")]
    public class SendScreenshotsController : ControllerBase
    {
        private readonly ILogger<SendScreenshotsController> _logger;
        private readonly IUpdateTicket _updateTicket;

        public SendScreenshotsController(
            ILogger<SendScreenshotsController> logger,           
            IUpdateTicket updateTicket)
        {
            _logger = logger;           
            _updateTicket = updateTicket;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromForm] IFormFile files)
        {
            try
            {
                 var result = await _updateTicket.SendScreenshotAsync(files);

                 if(!result)
                 {
                    return NotFound("Ticket not found or error occurred while sending the screenshot.");
                 }

                 return Ok(result);
            }catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while sending screenshots.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
           
        }
    }
}