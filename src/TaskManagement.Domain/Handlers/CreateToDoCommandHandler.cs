using System.Threading.Tasks;
using Flunt.Notifications;
using TaskManagement.Domain.Commands;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Repositories;
using TaskManagement.Shared.Commands;
using TaskManagement.Shared.Commands.Contracts;
using TaskManagement.Shared.Handlers.Contracts;

namespace TaskManagement.Domain.Handlers
{
    public class CreateToDoCommandHandler : Notifiable, ICommandHandler<CreateToDoCommand>
    {
        private readonly IToDoRepository _repository;

        public CreateToDoCommandHandler(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateToDoCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false,
                    "Oops, apparently your ToDo is invalid.", 
                    command.Notifications);

            var toDo = new ToDo(command.Title,
                                command.Description,
                                command.StartedAt,
                                command.User);

            await _repository.AddAsync(toDo);

            return new GenericCommandResult(true, "Success when adding To Do.", toDo);
        }
    }
}