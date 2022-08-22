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

        [HttpGet("{id:int}")]
        public ToDoModel GetById([FromRoute] int id)
        {
            return _appDbContext.ToDos.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public ToDoModel Post([FromBody] ToDoModel model)
        {
            _appDbContext.ToDos.Add(model);
            _appDbContext.SaveChanges();
            return model;
        }

        [HttpPut("{id:int}")]
        public ToDoModel Put([FromRoute] int id, [FromBody] ToDoModel ToDo)
        {
            var toDo = _appDbContext.ToDos.FirstOrDefault(x => x.Id == id);

            if (toDo == null)
            {
                return toDo;
            }

            toDo.Title = ToDo.Title;
            toDo.Done = ToDo.Done;

            _appDbContext.ToDos.Update(toDo);
            _appDbContext.SaveChanges();

            return toDo;
        }

        [HttpDelete("{id:int}")]
        public ToDoModel Delete([FromRoute] int id)
        {
            var model = _appDbContext.ToDos.FirstOrDefault(x => x.Id == id);
            _appDbContext.ToDos.Remove(model);
            _appDbContext.SaveChanges();
            return model;
        }
    }
}
