using System;
using System.Threading.Tasks;
using Actio.Common.Events;

namespace Actio.Api.Handlers
{
    public class AuthenticateUserHandler : IEventHandler<UserAuthenticated>
    {
        public async Task HandlerAsync(UserAuthenticated @event)
        {
            await Task.CompletedTask;

            Console.WriteLine($"Activỉty Created: {@event.Email}");
        }
    }
}