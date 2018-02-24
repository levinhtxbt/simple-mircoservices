using System;
using Actio.Services.Activities.Exceptions;

namespace Actio.Services.Activities.Domain.Models
{
    public class Activity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Category { get; set; }

        public Guid UserId { get; set; }

        protected Activity()
        {
        }

        public Activity(Guid id, string name, string description, Category category, Guid userId, DateTime createdAt)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ActioException("empty_activity_name",
                    "Do not allow empty activity name");
            }
            Id = Id;
            Name = name;
            Description = description;
            Category = category.Name;
            UserId = userId;
            CreatedAt = createdAt;
        }
    }
}