using System.Threading.Tasks;
using TaskManagement.Shared.Commands.Contracts;

namespace TaskManagement.Shared.Handlers.Contracts
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}