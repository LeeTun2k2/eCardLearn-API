using API.Data.Entities;

namespace API.Data.Repositories.Interfaces
{
    /// <summary>
    /// Notification
    /// </summary>
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        /// <summary>
        /// Get Notification by Teacher id
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        Task<IEnumerable<Notification>> GetByTeacherId(Guid TeacherId);

        /// <summary>
        /// Get Notification by Class id
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        Task<IEnumerable<Notification>> GetByClassId(Guid ClassId);
    }
}
