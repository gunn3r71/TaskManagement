using Flunt.Notifications;
using Flunt.Validations;
using System;
using TaskManagement.Shared.Commands.Contracts;

namespace TaskManagement.Domain.Commands
{
    public class MarkToDoAsDoneCommand : Notifiable, ICommand
    {
        public MarkToDoAsDoneCommand()
        {
        }

        public MarkToDoAsDoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNull(Id, nameof(Id), "Id cannot be null.")
                .HasLen(Id.ToString(), 36, nameof(Id), "Id must be greater than or equal to 36 characters")
                .IsNullOrEmpty(User, nameof(User), "User cannot be null.")
            );
        }
    }
}