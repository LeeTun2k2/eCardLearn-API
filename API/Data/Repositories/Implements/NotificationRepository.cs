using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        /// <summary>
        /// Get Notification by Teacher id
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Notification>> GetByTeacherId(Guid TeacherId)
        {
            return await Entities
                .Where(x => x.TeacherId == TeacherId)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Get Notification by Class id
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Notification>> GetByClassId(Guid ClassId)
        {
            return await Entities
                .Where(x => x.ClassId == ClassId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
