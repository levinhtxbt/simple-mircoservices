using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Actio.Api.Controllers
{
    [Route("activities")]
    public class ActivitiesController : Controller
    {
        private readonly IBusClient _bus;

        public ActivitiesController(IBusClient bus)
        {
            _bus = bus;
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] CreateActivity command)
        {
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;
            
            await _bus.PublishAsync(command);

            return Accepted($"activities/{command.Id}");
        }
    }
}