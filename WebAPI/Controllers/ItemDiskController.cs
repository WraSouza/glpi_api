using Application.IApplications.GetDeviceById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemDiskController(IGetDeviceById deviceById) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemDisks(int id)
        { 
            var deviceInfo =  await deviceById.GetDeviceByIdAsync(id);

            return Ok(deviceInfo);
        }
    }
}
