using Actio.Common.Commands;
using Actio.Common.Events;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Identity.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IBusClient _bus;

        public CreateUserHandler(IBusClient bus)
        {
            _bus = bus;
        }

        public async Task HandlerAsync(CreateUser command)
        {
            Console.WriteLine($"Receive CreateActivity command:{command.Email}");
            await _bus.PublishAsync<UserCreated>(new UserCreated(command.Email, command.Name));
        }
    }
}
