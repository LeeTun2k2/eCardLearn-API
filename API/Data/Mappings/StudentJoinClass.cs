using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.StudentJoinClass;

namespace API.Data
{
    /// <summary>
    /// StudentJoinClass maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for StudentJoinClass model
        /// </summary>
        protected void MapStudentJoinClass()
        {
            CreateMap<StudentJoinClass, StudentJoinClassViewModel>().ReverseMap();
            CreateMap<StudentJoinClass, StudentJoinClassAddModel>().ReverseMap();
            CreateMap<StudentJoinClass, StudentJoinClassEditModel>().ReverseMap();
        }
    }
}
