using System;

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

        public Activity(string name, string description, Category category, Guid userId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Category = category.Name;
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
        }

    }
}