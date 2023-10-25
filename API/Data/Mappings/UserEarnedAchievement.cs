using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.UserEarnedAchievement;

namespace API.Data
{
    /// <summary>
    /// UserEarnedAchievement maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for UserEarnedAchievement model
        /// </summary>
        protected void MapUserEarnedAchievement()
        {
            CreateMap<UserEarnedAchievement, UserEarnedAchievementViewModel>().ReverseMap();
            CreateMap<UserEarnedAchievement, UserEarnedAchievementAddModel>().ReverseMap();
            CreateMap<UserEarnedAchievement, UserEarnedAchievementEditModel>().ReverseMap();
        }
    }
}
