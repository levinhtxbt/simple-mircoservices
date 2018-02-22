using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using RawRabbit;
using RawRabbit.Pipe;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RawRabbit.Instantiation;

namespace Actio.Common.RabbitMq
{
    public static class Extensions
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus, ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandlerAsync(msg),
                ctx => ctx.UseSubscribeConfiguration(cfg => cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));

        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus, IEventHandler<TEvent> handler) where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(msg => handler.HandlerAsync(msg),
                ctx => ctx.UseSubscribeConfiguration(cfg => cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));

        private static string GetQueueName<T>()
            => $"{Assembly.GetEntryAssembly().GetName().Name}.{typeof(T).Name}";

        public static void AddRabbitMq(this IServiceCollection service, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("RabbitMq");
            section.Bind(options);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });

            service.AddSingleton<IBusClient>(_ => client);

        }
    }
}