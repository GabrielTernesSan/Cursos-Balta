using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {

        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "usuarioA"));
            _items.Add(new TodoItem("Tarefa 2", DateTime.Now, "usuarioB"));
            _items.Add(new TodoItem("Tarefa 3", DateTime.Now, "GabrielTernes"));
            _items.Add(new TodoItem("Tarefa 4", DateTime.Now, "usuarioD"));
            _items.Add(new TodoItem("Tarefa 5", DateTime.Now, "GabrielTernes"));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_que_fez_a_chamada()
        {
            var result = _items.AsQueryable().Where(ToDoQueries.GetAll("GabrielTernes"));
            Assert.AreEqual(2, result.Count());
        }
    }
}
