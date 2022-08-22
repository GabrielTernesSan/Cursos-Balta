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
        public List<ToDoModel> Get() => _appDbContext.ToDos.ToList();

        [HttpPost]
        public ToDoModel Post([FromBody] ToDoModel model)
        {
            _appDbContext.ToDos.Add(model);
            _appDbContext.SaveChanges();
            return model;
        }
    }
}
