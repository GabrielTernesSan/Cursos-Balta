using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        // Health Check
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                status = "Online"
            });
        }
    }
}
