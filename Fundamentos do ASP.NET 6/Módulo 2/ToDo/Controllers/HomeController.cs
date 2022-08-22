using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        //[HttpGet("/banana")] Não precisa de [Route]
        //[Route("/banana")]
        public string Get()
        {
            return "Salve";
        }
    }
}
