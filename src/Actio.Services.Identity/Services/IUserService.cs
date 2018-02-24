using System.Threading.Tasks;

namespace Actio.Services.Identity.Services
{
    public interface IUserService
    {
        Task Register(string email, string password, string name);

        Task Login(string email, string password);
    }
}