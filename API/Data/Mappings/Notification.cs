using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.Notification;

namespace API.Data
{
    /// <summary>
    /// Notification maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for Notification model
        /// </summary>
        protected void MapNotification()
        {
            CreateMap<Notification, NotificationViewModel>().ReverseMap();
            CreateMap<Notification, NotificationAddModel>().ReverseMap();
            CreateMap<Notification, NotificationEditModel>().ReverseMap();
        }
    }
}
