using System;
using System.Threading.Tasks;
using Actio.Api.Models;
using Actio.Api.Repositories;
using Actio.Common.Events;

namespace Actio.Api.Handlers
{
    public class CreateActivityHandler : IEventHandler<ActivityCreated>, IEventHandler<CreateActivtyRejected>
    {
        private readonly IActivityRepository _activityRepository;
        public CreateActivityHandler(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task HandlerAsync(ActivityCreated @event)
        {
            await _activityRepository.AddAsync(new Activity
            {
                Id = @event.Id,
                Name = @event.Name,
                Description = @event.Description,
                Category = @event.Description,
                UserId = @event.UserId
            });

            Console.WriteLine($"Activỉty Created: {@event.Name}");
        }

        public async Task HandlerAsync(CreateActivtyRejected @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Create Activity Rejected: {@event.Code} -> {@event.Reason}");
        }
    }
}