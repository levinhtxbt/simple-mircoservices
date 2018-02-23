using System.Threading.Tasks;
using Actio.Common.Mongo;
using MongoDB.Driver;
using Actio.Services.Activities.Domain.Repositories;
using System.Collections.Generic;
using Actio.Services.Activities.Domain.Models;
using System.Linq;

namespace Actio.Services.Activities.Services
{
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly ICategoryRepository _categoryRepostory;

        public CustomMongoSeeder(IMongoDatabase database,
            ICategoryRepository categoryRepostory) : base(database)
        {
            this._categoryRepostory = categoryRepostory;
        }

        protected override async Task CustomSeedAsync()
        {
            var categories = new List<string>
            {
               "sport",
               "work",
               "hobby"
            };
            
            await Task.WhenAll(categories.Select(x =>
                _categoryRepostory.AddAsync(new Category(x))));
        }
    }
}