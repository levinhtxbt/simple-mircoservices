using System.Threading.Tasks;
using Actio.Common.Auth;
using Actio.Common.Exceptions;
using Actio.Services.Identity.Domain.Models;
using Actio.Services.Identity.Domain.Repositories;
using Actio.Services.Identity.Domain.Services;

namespace Actio.Services.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IEncryptor _encryptor;

        private readonly IJwtHandler _jwtHandler;

        public UserService(IUserRepository userRepository,
            IEncryptor encryptor,
            IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
            _encryptor = encryptor;
            _userRepository = userRepository;
        }

        public async Task<JsonWebToken> Login(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new ActioException("invalid_email",
                    "Email {0} is invalid", email);
            }

            if (!user.VerifyPassword(password, _encryptor))
            {
                throw new ActioException("invalid_password",
                    "Password is incorrect");
            }

            // Generate JWT
            return _jwtHandler.Create(user.Id);
        }

        public async Task Register(string email, string password, string name)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new ActioException("exists_email",
                    "Email {0} has already been taken", email);
            }
            user = new User(email, name);
            user.SetPassword(password, _encryptor);
            await _userRepository.AddAsync(user);
        }
    }
}