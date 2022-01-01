using System;
using TaskManagement.Shared.Entities;

namespace TaskManagement.Domain.Entities
{
    public class ToDo : Entity
    {
        public ToDo(string title, 
            string description,
            DateTime startedAt,
            string user)
        {
            Title = title;
            Description = description;
            StartedAt = startedAt;
            User = user;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool Done { get; private set; }
        public DateTime StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public string User { get; private set; }

        public void MarkAsDone()
        {
            if (Done) 
                AddNotification(nameof(Done), "Task is already marked complete.");

            Done = true;
            FinishedAt = DateTime.UtcNow.AddHours(-3);
        }

        public void MarkAsUndone()
        {
            if(!Done)
                AddNotification(nameof(Done), "Task is already marked uncompleted.");

            Done = false;
            FinishedAt = null;
        }
    }
}