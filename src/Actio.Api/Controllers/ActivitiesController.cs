using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Actio.Api.Repositories;
using Actio.Common.Commands;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Actio.Api.Controllers
{
    [Route("activities")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ActivitiesController : Controller
    {
        private readonly IBusClient _bus;
        private readonly IActivityRepository _activityRepository;

        public ActivitiesController(IBusClient bus,
            IActivityRepository activityRepository)
        {
            _bus = bus;
            _activityRepository = activityRepository;
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] CreateActivity command)
        {

            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;
            command.UserId = Guid.Parse(User.Identity.Name);
            await _bus.PublishAsync(command);

            return Accepted($"activities/{command.Id}");
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var userId = Guid.Parse(User.Identity.Name);
            Console.WriteLine(userId.ToString());
            var activities = await _activityRepository.BrowseAsync(userId);

            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var activity = await _activityRepository.GetAsync(Guid.Parse(id));

            if (activity == null)
                return NotFound();
            if (activity.UserId != userId)
                return Unauthorized();

            return Ok(activity);
        }
    }
}