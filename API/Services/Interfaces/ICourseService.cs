using API.Data.DTOs.Course;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Course Service Interface
    /// </summary>
    public interface ICourseService : IBaseService<Course, CourseViewModel, CourseAddModel, CourseEditModel, CourseFilterModel>
    {
        /// <summary>
        /// Get Course by Teacher id
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        Task<IEnumerable<CourseViewModel>> GetByTeacherId(Guid TeacherId);
    }
}
