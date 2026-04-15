using Application.IApplications.GetAllDevices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotebooksController(IGetAllDevices allDevices) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDevices()
        {
            var devices = await allDevices.GetAllDevicesAsync();

            return Ok(devices);
        }
    }
}
