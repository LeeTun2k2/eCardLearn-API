using API.Data.DTOs.Achievement;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Achievement Service Interface
    /// </summary>
    public interface IAchievementService : IBaseService<Achievement, AchievementViewModel, AchievementAddModel, AchievementEditModel, AchievementFilterModel>
    {

    }
}
