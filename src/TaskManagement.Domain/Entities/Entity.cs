using System;

namespace TaskManagement.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public virtual Guid Id  { get; }

        public bool Equals(Entity other)
        {
            return Id.Equals(other?.Id);
        }
    }
}