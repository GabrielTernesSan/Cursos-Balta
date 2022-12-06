using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Handler;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : Controller
    {
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "GabrielTernes";
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
