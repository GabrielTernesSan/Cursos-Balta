using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        //[HttpGet("/banana")] Não precisa de [Route]
        //[Route("/banana")]
        public List<ToDoModel> Get() => _appDbContext.ToDos.ToList();
    }
}
