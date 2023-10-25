using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.Course;

namespace API.Data
{
    /// <summary>
    /// Course maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for Course model
        /// </summary>
        protected void MapCourse()
        {
            CreateMap<Course, CourseViewModel>().ReverseMap();
            CreateMap<Course, CourseAddModel>().ReverseMap();
            CreateMap<Course, CourseEditModel>().ReverseMap();
        }
    }
}
