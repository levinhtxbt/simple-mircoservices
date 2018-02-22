using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using RawRabbit;

namespace Actio.Services.Identity.Handlers
{
    public class AuthenticateUserHandler : ICommandHandler<AuthenticateUser>
    {
        private readonly IBusClient _bus;

        public AuthenticateUserHandler(IBusClient bus)
        {
            _bus = bus;
        }
        public async Task HandlerAsync(AuthenticateUser command)
        {
            Console.WriteLine($"Receive CreateActivity command:{command.Email}");

            await _bus.PublishAsync<UserAuthenticated>(new UserAuthenticated(command.Email));
        }
    }
}