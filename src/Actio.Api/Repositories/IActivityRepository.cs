using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Actio.Api.Models;

namespace Actio.Api.Repositories
{
    public interface IActivityRepository
    {
         Task AddAsync(Activity activity);

         Task<IEnumerable<Activity>> BrowseAsync(Guid userId);

         Task<Activity> GetAsync(Guid id);

    }
}