using API.Commons.Paginations;
using API.Data.DTOs.UserLoginHistory;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// UserLoginHistory service
    /// </summary>
    public class UserLoginHistoryService : IUserLoginHistoryService
    {
        private readonly IUserLoginHistoryRepository _repository;
        private readonly IAchievementRepository _achievementRepository;
        private readonly IUserEarnedAchievementRepository _userEarnedAchievementRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="achievementRepository"></param>
        /// <param name="userEarnedAchievementRepository"></param>
        /// <param name="mapper"></param>
        public UserLoginHistoryService(
            IUserLoginHistoryRepository repository, 
            IAchievementRepository achievementRepository, 
            IUserEarnedAchievementRepository userEarnedAchievementRepository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _achievementRepository = achievementRepository;
            _userEarnedAchievementRepository = userEarnedAchievementRepository;
        }

        /// <summary>
        /// Get User login history
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserLoginHistoryViewModel>?> GetUserLoginHistory(Guid UserId)
        {
            var data = await _repository.GetByUserId(UserId);

            return _mapper.Map<IEnumerable<UserLoginHistoryViewModel>>(data);
        }

        /// <summary>
        /// Write Login history
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<bool> WriteLoginHistory(Guid UserId)
        {
            var latest = await _repository.GetLatest(UserId);
            var current = DateTime.Now;

            var add = 1;
            if (latest != null && latest.LoginDateTime.Date == current.Date)
            {
                add = 0;
            }

            var newRecord = new UserLoginHistory();
            newRecord.UserId = UserId;
            newRecord.LoginDateTime = current;
            newRecord.Count = (latest?.Count ?? 0) + add;

            var result = await _repository.AddAsync(newRecord);

            if (result != null)
            {
                return false;
            }

            if (latest != null && latest.Count != newRecord.Count)
            {
                var achivement = await _achievementRepository.GetByDay(newRecord.Count);

                if (achivement != null)
                {
                    var earnAchievement = new UserEarnedAchievement();
                    earnAchievement.UserId = UserId;
                    earnAchievement.AchievementId = achivement.AchievementId;

                    var uea = _userEarnedAchievementRepository.AddAsync(earnAchievement);

                    if (uea == null)
                    {
                        Console.WriteLine("Can not earn achievement.");
                    }
                }
            }

            return true;
        }
    }
}
