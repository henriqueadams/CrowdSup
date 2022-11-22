using Microsoft.AspNetCore.Mvc;

namespace CrowdSup.Api.Controllers
{
    [ApiController]
    [Route("check")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<dynamic>> CheckAsync()
        {
            return Ok("Checked");
        }
    }
}