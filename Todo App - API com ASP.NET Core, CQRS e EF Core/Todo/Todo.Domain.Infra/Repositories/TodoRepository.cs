using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {

        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(TodoItem todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public TodoItem GetById(Guid id, string user)
        {
            var todoItem = _context.Todos.FirstOrDefault(x => x.Id == id && x.User == user);
            return todoItem;
        }

        public void Update(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            return _context.Todos.AsNoTracking().Where(ToDoQueries.GetAll(user)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _context.Todos.AsNoTracking().Where(ToDoQueries.GetAllDone(user)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            return _context.Todos.AsNoTracking().Where(ToDoQueries.GetAllUndone(user)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetbyPeriod(string user, DateTime date, bool done)
        {
            return _context.Todos.AsNoTracking().Where(ToDoQueries.GetByPeriod(user, date, done)).OrderBy(x => x.Date);
        }
    }
}
