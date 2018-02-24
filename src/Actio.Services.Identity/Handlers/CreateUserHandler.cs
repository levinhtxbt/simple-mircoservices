using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.Exceptions;
using Actio.Services.Identity.Services;
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
        private readonly IUserService _userService;

        public CreateUserHandler(IBusClient bus, IUserService userService)
        {
            _userService = userService;
            _bus = bus;
        }

        public async Task HandlerAsync(CreateUser command)
        {
            Console.WriteLine($"Receive Create User Command:{command.Email}");
            try
            {
                await _userService.Register(command.Email, command.Password, command.Name);
                await _bus.PublishAsync(new UserCreated(command.Email, command.Name));

                return;
            }
            catch (ActioException ex)
            {
                await _bus.PublishAsync(new CreateUserRejected(ex.Code, ex.Message));
            }
            catch (Exception ex)
            {
                await _bus.PublishAsync(new CreateUserRejected("error", ex.Message));
            }
        }
    }
}
