using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.Exceptions;
using Actio.Services.Identity.Services;
using RawRabbit;

namespace Actio.Services.Identity.Handlers
{
    public class AuthenticateUserHandler : ICommandHandler<AuthenticateUser>
    {
        private readonly IBusClient _bus;
        private readonly IUserService _userService;

        public AuthenticateUserHandler(IBusClient bus, IUserService userService)
        {
            _userService = userService;
            _bus = bus;
        }
        public async Task HandlerAsync(AuthenticateUser command)
        {
            Console.WriteLine($"Receive Authenticate User Command:{command.Email}");
            try
            {
                await _userService.Login(command.Email, command.Password);
                await _bus.PublishAsync(new UserAuthenticated(command.Email, "token here"));

                return;
            }
            catch (ActioException ex)
            {
                await _bus.PublishAsync(new AuthenticateUserRejected(ex.Code, ex.Message));
            }
            catch (Exception ex)
            {
                await _bus.PublishAsync(new AuthenticateUserRejected("error", ex.Message));
            }
        }
    }
}