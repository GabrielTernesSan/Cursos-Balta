using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Salve";
        }
    }
}
