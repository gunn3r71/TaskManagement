using System.Threading.Tasks;
using Flunt.Notifications;
using TaskManagement.Domain.Commands;
using TaskManagement.Domain.Repositories;
using TaskManagement.Shared.Commands;
using TaskManagement.Shared.Commands.Contracts;
using TaskManagement.Shared.Handlers.Contracts;

namespace TaskManagement.Domain.Handlers
{
    public class MarkToDoAsUndoneCommandHandler : Notifiable, ICommandHandler<MarkToDoAsUndoneCommand>
    {
        private readonly IToDoRepository _repository;

        public MarkToDoAsUndoneCommandHandler(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(MarkToDoAsUndoneCommand command)
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

            toDo.MarkAsUndone();

            await _repository.UpdateAsync(toDo);

            return new GenericCommandResult(true, "Success when updating your to do", toDo);
        }
    }
}