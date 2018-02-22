using System;
using System.Threading.Tasks;
using Actio.Common.Events;

namespace Actio.Api.Handlers
{
    public class CreateActivityHandler : IEventHandler<ActivityCreated>
    {
        public async Task HandlerAsync(ActivityCreated @event)
        {
            await Task.CompletedTask;
            
            Console.WriteLine($"Activỉty Created: {@event.Name}");
        }
    }
}