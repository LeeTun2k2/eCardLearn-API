using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.Authentication;

namespace API.Data
{
    /// <summary>
    /// User maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for User model
        /// </summary>
        protected void MapUser()
        {
            CreateMap<User, UserProfileModel>().ReverseMap();
        }
    }
}
