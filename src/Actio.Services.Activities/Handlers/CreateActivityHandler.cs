using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Services.Activities.Exceptions;
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
            Console.WriteLine($"Receive CreateActivity command:{command.Name}");
            try
            {
                await _activityService.AddAsync(command.Id, command.Name, command.Description,
                    command.Category, command.UserId, command.CreatedAt);
            }
            catch (ActioException ex)
            {
                await _bus.PublishAsync<CreatedActivtyRejected>(new CreatedActivtyRejected(ex.Code, ex.Message));
            }
            catch (Exception ex)
            {
                await _bus.PublishAsync<CreatedActivtyRejected>(new CreatedActivtyRejected("error", ex.Message));
            }
        }
    }
}