using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.CourseInClass;

namespace API.Data
{
    /// <summary>
    /// CourseInClass maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for CourseInClass model
        /// </summary>
        protected void MapCourseInClass()
        {
            CreateMap<CourseInClass, CourseInClassViewModel>().ReverseMap();
            CreateMap<CourseInClass, CourseInClassAddModel>().ReverseMap();
            CreateMap<CourseInClass, CourseInClassEditModel>().ReverseMap();
        }
    }
}
