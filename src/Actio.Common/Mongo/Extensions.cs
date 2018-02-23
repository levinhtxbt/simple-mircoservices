using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Actio.Common.Mongo
{
    public static class Extensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<MongoOption>(configuration.GetSection("Mongo"));
            service.AddSingleton<MongoClient>(c =>
            {
                var option = c.GetService<IOptions<MongoOption>>();
                return new MongoClient(option.Value.ConnectionString);
            });
            service.AddScoped<IMongoDatabase>(c =>
            {
                var option = c.GetService<IOptions<MongoOption>>();
                var client = c.GetService<MongoClient>();
                return client.GetDatabase(option.Value.Database);
            });
            service.AddScoped<IDatabaseInitializer, MongoInitializer>();

            return service;
        }
    }
}