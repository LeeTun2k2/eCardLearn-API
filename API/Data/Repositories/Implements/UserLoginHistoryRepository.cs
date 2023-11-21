using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// UserLoginHistory Repository
    /// </summary>
    public class UserLoginHistoryRepository : BaseRepository<UserLoginHistory>, IUserLoginHistoryRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public UserLoginHistoryRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }

        /// <summary>
        /// Get User by id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserLoginHistory>?> GetByUserId(Guid UserId)
        {
            return await Entities
                .Where(x => x.UserId == UserId)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Get lastest record
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<UserLoginHistory?> GetLatest(Guid UserId)
        {
            return await Entities
                .Where(x => x.UserId == UserId)
                .OrderByDescending(x => x.LoginDateTime)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
