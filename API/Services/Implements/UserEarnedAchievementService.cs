using API.Commons.Paginations;
using API.Data.DTOs.Authentication;
using API.Data.DTOs.Achievement;
using API.Data.DTOs.UserEarnedAchievement;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// UserEarnedAchievement service
    /// </summary>
    public class UserEarnedAchievementService : BaseService<UserEarnedAchievement, UserEarnedAchievementViewModel, UserEarnedAchievementAddModel, UserEarnedAchievementEditModel, UserEarnedAchievementFilterModel>, IUserEarnedAchievementService
    {
        private new readonly IUserEarnedAchievementRepository _repository;
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="userManager"></param>
        /// <param name="mapper"></param>
        public UserEarnedAchievementService(
            IUserEarnedAchievementRepository repository, 
            UserManager<User> userManager,
            IMapper mapper) 
            : base(repository, mapper)
        {
            _repository = repository;
            _userManager = userManager;
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

        /// <summary>
        /// Get Achievement by User id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AchievementViewModel>?> GetAchievementByUserId(Guid UserId)
        {
            var entities = await _repository.GetAchievementsByUserId(UserId);

            var models = _mapper.Map<IEnumerable<AchievementViewModel>>(entities);

            return models;
        }

        /// <summary>
        /// Get User by Achievement id
        /// </summary>
        /// <param name="AchievementId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserProfileModel>?> GetUserByAchievementId(Guid AchievementId)
        {
            var ids = await _repository.GetUserIdByAchivementId(AchievementId) ?? new List<Guid>();
            var models = new List<User>();

            foreach (var id in ids)
            {
                var user = await _userManager.FindByIdAsync(id.ToString());

                if (user != null)
                    models.Add(user);
            }

            var data = _mapper.Map<IEnumerable<UserProfileModel>>(models);

            return data;
        }
    }
}
