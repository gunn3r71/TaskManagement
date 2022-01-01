using System.Threading.Tasks;
using Flunt.Notifications;
using TaskManagement.Domain.Commands;
using TaskManagement.Domain.Repositories;
using TaskManagement.Shared.Commands;
using TaskManagement.Shared.Commands.Contracts;
using TaskManagement.Shared.Handlers.Contracts;

namespace TaskManagement.Domain.Handlers
{
    public class MarkToDoAsDoneCommandHandler : Notifiable, ICommandHandler<MarkToDoAsDoneCommand>
    {
        private readonly IToDoRepository _repository;

        public MarkToDoAsDoneCommandHandler(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(MarkToDoAsDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false,
                    "Oops, apparently your ToDo is invalid.",
                    command.Notifications);

            var toDo = await _repository.GetByIdAsync(command.Id, command.User);

            if (toDo is null)
                return new GenericCommandResult(false,
                    "Oops, apparently your ToDo Doesn't exist",
                    null);

            toDo.MarkAsDone();

            await _repository.UpdateAsync(toDo);

            return new GenericCommandResult(true, "Success when updating your to do", toDo);
        }
    }
}