using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Actio.Services.Activities.Domain.Models;

namespace Actio.Services.Activities.Domain.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetByIdAsync(Guid id);

        Task AddAsync(Activity activity);
    }
}