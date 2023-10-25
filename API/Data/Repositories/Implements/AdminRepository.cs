using API.Data.Entities;
using API.Data.Repositories.Interfaces;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// Admin Repository
    /// </summary>
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public AdminRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }
    }
}
