using System;
using System.Threading.Tasks;
using Actio.Common.Exceptions;
using Actio.Services.Activities.Domain.Models;
using Actio.Services.Activities.Domain.Repositories;

namespace Actio.Services.Activities.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ActivityService(
            ICategoryRepository categoryRepository,
            IActivityRepository activityRepository)
        {
            _categoryRepository = categoryRepository;
            _activityRepository = activityRepository;
        }

        public async Task AddAsync(Guid id, string name, string description, 
            string categoryName, Guid userId, DateTime createdAt)
        {
            var category = await _categoryRepository.GetAsync(categoryName);
            if (category == null)
            {
                throw new ActioException("category_not_found",
                    "Category {0} was not found", category);
            }

            await _activityRepository.AddAsync(new Activity(id, name, description, category, userId, createdAt));
        }
    }
}