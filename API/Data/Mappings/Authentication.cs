using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.Authentication;

namespace API.Data
{
    /// <summary>
    /// Authentication maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for Authentication model 
        /// </summary>
        protected void MapAuthentication()
        {
            CreateMap<User, RegisterModel>().ReverseMap();
        }
    }
}
