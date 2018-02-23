using System;

namespace Actio.Services.Activities.Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        protected Category()
        {
        }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name.ToLowerInvariant();
        }
    }
}