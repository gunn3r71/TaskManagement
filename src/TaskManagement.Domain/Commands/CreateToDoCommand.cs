using Flunt.Notifications;
using Flunt.Validations;
using System;
using TaskManagement.Shared.Commands;

namespace TaskManagement.Domain.Commands
{
    public class CreateToDoCommand : Notifiable, ICommand
    {
        public CreateToDoCommand()
        {
        }

        public CreateToDoCommand(string title,
                                 string user,
                                 string description)
        {
            Title = title;
            User = user;
            Description = description;
        }

        public CreateToDoCommand(string title,
                                 string user,
                                 DateTime? startedAt, 
                                 string description)
            : this(title, user, description)
        {
            StartedAt = startedAt;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string User { get; set; }
        public DateTime? StartedAt { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
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