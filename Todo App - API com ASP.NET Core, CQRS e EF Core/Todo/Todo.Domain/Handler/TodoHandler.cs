﻿using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Repositories;
using static Todo.Domain.Handler.Contracts.IHandler;

namespace Todo.Domain.Handler
{
    public class TodoHandler : Notifiable, IHandler<CreateTodoCommand>
    {

        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua tarefa está errada", 
                    command.Notifications);
            }

        }
    }
}
