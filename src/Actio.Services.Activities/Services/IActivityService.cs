using System;
using System.Threading.Tasks;
using Actio.Services.Activities.Domain.Models;

namespace Actio.Services.Activities.Services
{
    public interface IActivityService
    {
        Task AddAsync(Guid id, string name, string description, string category, Guid userId, DateTime createdAt);
        
    }
}