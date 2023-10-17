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
        protected void MapUser()
        {
            CreateMap<User, UserProfileModel>().ReverseMap();
        }
    }
}
