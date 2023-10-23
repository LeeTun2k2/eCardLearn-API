using API.Commons.Paginations;
using API.Data.DTOs.Achievement;
using API.Data.Entities;
using API.Data.Repositories;
using API.Services.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// Achievement service
    /// </summary>
    public class AchievementService : BaseService<Achievement, AchievementViewModel, AchievementAddModel, AchievementEditModel, AchievementFilterModel>, IAchievementService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public AchievementService(IBaseRepository<Achievement> repository, IMapper mapper) 
            : base(repository, mapper)
        {

        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<AchievementViewModel>?> GetAsync(AchievementFilterModel filter)
        {
            // Default filter condition
            Expression<Func<Achievement, bool>> filterExpression = p => true; 

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.AchievementName))
                    filterExpression = p => p.AchievementName.Contains(filter.AchievementName);

                if (!string.IsNullOrEmpty(filter.AchievementDescription))
                    filterExpression = p => p.AchievementDescription.Contains(filter.AchievementDescription);
            }

            // Default orderBy
            Func<IQueryable<Achievement>, IOrderedQueryable<Achievement>> orderBy = q => q.OrderBy(p => p.AchievementName); 

            // Define pagination parameters (skip and take)
            PaginationParameters pagination = new ()
            {
                PageNumber = filter?.PageNumber ?? PaginationDefaultValues.PageNumber,
                PageSize = filter?.PageSize ?? PaginationDefaultValues.PageSize
            };

            // Retrieve the data from the repository using the filter, orderBy, and pagination
            var entities = await _repository.GetAsync(filterExpression, orderBy, pagination);

            // Map the retrieved entities to ViewModel
            var models = _mapper.Map<IEnumerable<AchievementViewModel>>(entities);

            return models;
        }
    }
}
