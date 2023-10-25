using API.Commons.Paginations;
using API.Data.DTOs.UserEarnedAchievement;
using API.Data.Entities;
using API.Data.Repositories;
using API.Services.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// UserEarnedAchievement service
    /// </summary>
    public class UserEarnedAchievementService : BaseService<UserEarnedAchievement, UserEarnedAchievementViewModel, UserEarnedAchievementAddModel, UserEarnedAchievementEditModel, UserEarnedAchievementFilterModel>, IUserEarnedAchievementService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public UserEarnedAchievementService(IBaseRepository<UserEarnedAchievement> repository, IMapper mapper) 
            : base(repository, mapper)
        {

        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<UserEarnedAchievementViewModel>?> GetAsync(UserEarnedAchievementFilterModel filter)
        {
            // Default filter condition
            Expression<Func<UserEarnedAchievement, bool>> filterExpression = p => true; 

            if (filter != null)
            {

            }

            // Default orderBy
            Func<IQueryable<UserEarnedAchievement>, IOrderedQueryable<UserEarnedAchievement>> orderBy = q => q.OrderBy(p => p.UserId); 

            // Define pagination parameters (skip and take)
            PaginationParameters pagination = new ()
            {
                PageNumber = filter?.PageNumber ?? PaginationDefaultValues.PageNumber,
                PageSize = filter?.PageSize ?? PaginationDefaultValues.PageSize
            };

            // Retrieve the data from the repository using the filter, orderBy, and pagination
            var entities = await _repository.GetAsync(filterExpression, orderBy, pagination);

            // Map the retrieved entities to ViewModel
            var models = _mapper.Map<IEnumerable<UserEarnedAchievementViewModel>>(entities);

            return models;
        }
    }
}
