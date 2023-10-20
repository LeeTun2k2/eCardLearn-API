using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.Achievement;

namespace API.Data
{
    /// <summary>
    /// Achievement maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for Achievement model
        /// </summary>
        protected void MapAchievement()
        {
            CreateMap<Achievement, AchievementViewModel>().ReverseMap();
            CreateMap<Achievement, AchievementAddModel>().ReverseMap();
            CreateMap<Achievement, AchievementEditModel>().ReverseMap();
        }
    }
}
