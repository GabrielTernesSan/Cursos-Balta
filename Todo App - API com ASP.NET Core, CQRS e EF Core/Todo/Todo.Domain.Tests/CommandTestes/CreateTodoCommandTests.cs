using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTestes;

[TestClass]
public class CreateTodoCommandTests
{
    [TestMethod]
    public void Dado_um_comando_invalido()
    {
        var command = new CreateTodoCommand("", "", DateTime.Now);
        command.Validate();
        Assert.AreEqual(command.Valid, false);
    }

    [TestMethod]
    public void Dado_um_comando_valido()
    {
        var command = new CreateTodoCommand("Titulo da Tarefa", "Gabriel Ternes", DateTime.Now);
        command.Validate();
        Assert.AreEqual(command.Valid, true);
    }
}