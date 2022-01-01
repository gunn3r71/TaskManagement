using System;
using Flunt.Notifications;

namespace TaskManagement.Shared.Entities
{
    public abstract class Entity : Notifiable, IEquatable<Entity>
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id  { get; }

        public bool Equals(Entity other)
        {
            return Id.Equals(other?.Id);
        }
    }
}