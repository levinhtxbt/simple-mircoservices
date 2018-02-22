using System;
using System.Threading.Tasks;
using Actio.Common.Events;

namespace Actio.Api.Handlers
{
    public class CreateUserHandler : IEventHandler<UserCreated>
    {
        public async Task HandlerAsync(UserCreated @event)
        {
            await Task.CompletedTask;

            Console.WriteLine($"User Created: {@event.Email}");
        }
    }
}