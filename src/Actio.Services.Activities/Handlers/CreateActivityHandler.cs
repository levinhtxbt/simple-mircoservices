using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using RawRabbit;

namespace Actio.Services.Activities.Handlers
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private readonly IBusClient _bus;
        public CreateActivityHandler(IBusClient bus)
        {
            _bus = bus;
        }
        public async Task HandlerAsync(CreateActivity command)
        {
            Console.WriteLine($"Receive CreateActivity command:{command.Name}");
            
            await _bus.PublishAsync<ActivityCreated>(new ActivityCreated(command.Id,
                command.UserId, command.Category, command.Name, command.Description));
        }
    }
}