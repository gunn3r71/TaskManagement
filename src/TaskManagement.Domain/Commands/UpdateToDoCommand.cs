using Flunt.Notifications;
using Flunt.Validations;
using System;
using TaskManagement.Shared.Commands.Contracts;

namespace TaskManagement.Domain.Commands
{
    public class UpdateToDoCommand : Notifiable, ICommand
    {
        public UpdateToDoCommand()
        {
        }

        public UpdateToDoCommand(Guid id,
                                 string title, 
                                 string description, 
                                 string user)
        {
            Id = id;
            Title = title;
            Description = description;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNull(Id, nameof(Id), "Id cannot be null.")
                .HasLen(Id.ToString(), 36, nameof(Id), "Id must be greater than or equal to 36 characters")
                .IsNullOrEmpty(Title, nameof(Title), "Title cannot be null.")
                .HasMinLen(Title, 4, nameof(Title), "Title must be greater than or equal to 4 characters.")
                .HasMaxLen(Title, 20, nameof(Title), "Title must be less than or equal to 20 characters.")
                .HasMinLen(Description, 6, nameof(Description), "Description must be greater than or equal to 6 characters.")
                .HasMaxLen(Description, 100, nameof(Description), "Description must be less than or equal to 100 characters.")
                .IsNullOrEmpty(User, nameof(User), "User cannot be null.")
            );
        }
    }
}