using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Actio.Common.Mongo
{
    public class MongoInitializer : IDatabaseInitializer
    {
        private bool _initializer;
        private readonly bool _seed;
        private readonly IMongoDatabase _database;
        private readonly IDatabaseSeeder _seeder;

        public MongoInitializer(
            IMongoDatabase database,
            IDatabaseSeeder seeder,
            IOptions<MongoOption> options)
        {
            _seeder = seeder;
            _database = database;
            _seed = options.Value.Seed;
        }

        public async Task InitializerAsync()
        {
            if (_initializer)
            {
                return;
            }
            RegisterConvention();
            _initializer = true;

            if (!_seed)
            {
                return;
            }

            await _seeder.SeedAsync();
        }

        private void RegisterConvention()
        {
            ConventionRegistry.Register("ActionConvetions", new MongoConvention(), f => true);
        }

    }

    public class MongoConvention : IConventionPack
    {
        public IEnumerable<IConvention> Conventions => new List<IConvention>
        {
            new IgnoreExtraElementsConvention(true),
            new CamelCaseElementNameConvention(),
            new EnumRepresentationConvention(BsonType.String)
        };
    }
}