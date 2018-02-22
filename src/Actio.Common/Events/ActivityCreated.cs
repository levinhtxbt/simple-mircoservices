using System;

namespace Actio.Common.Events
{
    public class ActivityCreated : IEvent
    {
        public Guid Id { get; }

        public Guid UserId { get; }

        public string Category { get; }

        public string Name { get; }

        public string Description { get; }

        protected ActivityCreated()
        {
        }

        public ActivityCreated(Guid id, Guid userId, string category, string name, string description)
        {
            Id = id;
            UserId = userId;
            Category = category;
            Name = name;
            Description = description;
        }
    }
}