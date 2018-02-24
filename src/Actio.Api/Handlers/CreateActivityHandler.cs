using System;
using System.Threading.Tasks;
using Actio.Common.Events;

namespace Actio.Api.Handlers
{
    public class CreateActivityHandler : IEventHandler<ActivityCreated>, IEventHandler<CreateActivtyRejected>
    {
        public async Task HandlerAsync(ActivityCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Activỉty Created: {@event.Name}");
        }

        public async Task HandlerAsync(CreateActivtyRejected @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Create Activity Rejected: {@event.Code} -> {@event.Reason}");
        }
    }
}