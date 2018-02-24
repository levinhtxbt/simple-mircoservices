using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.Exceptions;
using Actio.Services.Activities.Services;
using RawRabbit;

namespace Actio.Services.Activities.Handlers
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private readonly IBusClient _bus;
        private readonly IActivityService _activityService;
        public CreateActivityHandler(IBusClient bus,
            IActivityService activityService)
        {
            _activityService = activityService;
            _bus = bus;
        }
        public async Task HandlerAsync(CreateActivity command)
        {
            Console.WriteLine($"Receive Create Activity command:{command.Name}");
            try
            {
                await _activityService.AddAsync(command.Id, command.Name, command.Description,
                    command.Category, command.UserId, command.CreatedAt);

                await _bus.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category,
                    command.Name, command.Description));

                return;
            }
            catch (ActioException ex)
            {
                await _bus.PublishAsync(new CreateActivtyRejected(ex.Code, ex.Message));
            }
            catch (Exception ex)
            {
                await _bus.PublishAsync(new CreateActivtyRejected("error", ex.Message));
            }
        }
    }
}