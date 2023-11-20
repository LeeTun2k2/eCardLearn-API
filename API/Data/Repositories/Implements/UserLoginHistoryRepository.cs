using API.Data.Entities;
using API.Data.Repositories.Interfaces;

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

        public Task<IEnumerable<UserLoginHistory>> GetByUserId(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public Task<UserLoginHistory> GetLatest()
        {
            throw new NotImplementedException();
        }
    }
}
