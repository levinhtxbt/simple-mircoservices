using System;
using System.Threading.Tasks;
using Actio.Common.Events;

namespace Actio.Api.Handlers
{
    public class AuthenticateUserHandler : IEventHandler<UserAuthenticated>, IEventHandler<AuthenticateUserRejected>
    {
        public async Task HandlerAsync(UserAuthenticated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"User Authenticated: {@event.Email}");
        }

        public async Task HandlerAsync(AuthenticateUserRejected @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Authenticate User Rejected: {@event.Code} -> {@event.Reason}");
        }
    }
}