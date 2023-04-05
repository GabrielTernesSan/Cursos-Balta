using Blog.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        // Health Check
        [HttpGet("")]
        //[ApiKey]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
