using API.Data.DTOs.Notification;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Notification Service Interface
    /// </summary>
    public interface INotificationService : IBaseService<Notification, NotificationViewModel, NotificationAddModel, NotificationEditModel, NotificationFilterModel>
    {
        /// <summary>
        /// Get Notification by Teacher id
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        Task<IEnumerable<NotificationViewModel>> GetByTeacherId(Guid TeacherId);

        /// <summary>
        /// Get Notification by Class id
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        Task<IEnumerable<NotificationViewModel>> GetByClassId(Guid ClassId);
    }
}
