using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.UserLoginHistory;

namespace API.Data
{
    /// <summary>
    /// UserLoginHistory maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for UserLoginHistory model
        /// </summary>
        protected void MapUserLoginHistory()
        {
            CreateMap<UserLoginHistory, UserLoginHistoryViewModel>().ReverseMap();
        }
    }
}
