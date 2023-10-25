using API.Data.DTOs.Notification;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Notification Service Interface
    /// </summary>
    public interface INotificationService : IBaseService<Notification, NotificationViewModel, NotificationAddModel, NotificationEditModel, NotificationFilterModel>
    {

    }
}
