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
        public IActionResult Get()
        {
            return Ok(_appDbContext.ToDos.ToList());
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var tarefa = _appDbContext.ToDos.FirstOrDefault(x => x.Id == id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ToDoModel model)
        {
            _appDbContext.ToDos.Add(model);
            _appDbContext.SaveChanges();

            return Created($"/{model.Id}", model);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] ToDoModel ToDo)
        {
            var toDo = _appDbContext.ToDos.FirstOrDefault(x => x.Id == id);

            if (toDo == null)
            {
                return NotFound();
            }

            toDo.Title = ToDo.Title;
            toDo.Done = ToDo.Done;

            _appDbContext.ToDos.Update(toDo);
            _appDbContext.SaveChanges();

            return Ok(toDo);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var model = _appDbContext.ToDos.FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            _appDbContext.ToDos.Remove(model);
            _appDbContext.SaveChanges();

            return Ok(model);
        }
    }
}
