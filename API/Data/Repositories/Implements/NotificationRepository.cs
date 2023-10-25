using API.Data.Entities;
using API.Data.Repositories.Interfaces;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// Notification Repository
    /// </summary>
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public NotificationRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }
    }
}
