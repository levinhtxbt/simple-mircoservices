using System;
using System.Threading.Tasks;
using Actio.Common.Events;

namespace Actio.Api.Handlers
{
    public class CreateUserHandler : IEventHandler<UserCreated>, IEventHandler<CreateUserRejected>
    {
        public async Task HandlerAsync(UserCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"User Created: {@event.Email}");
        }

        public async Task HandlerAsync(CreateUserRejected @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Create User Rejected: {@event.Code} -> {@event.Reason}");
        }
    }
}