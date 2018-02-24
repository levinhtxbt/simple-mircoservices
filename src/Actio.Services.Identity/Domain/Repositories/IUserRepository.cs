using System;
using System.Threading.Tasks;
using Actio.Services.Identity.Domain.Models;

namespace Actio.Services.Identity.Domain.Repositories
{
    public interface IUserRepository
    {
         Task AddAsync(User user);

         Task<User> GetAsync(Guid id);

         Task<User> GetAsync(string email);
    }
}