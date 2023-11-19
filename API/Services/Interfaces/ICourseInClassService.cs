using API.Data.DTOs.Class;
using API.Data.DTOs.Course;
using API.Data.DTOs.CourseInClass;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// CourseInClass Service Interface
    /// </summary>
    public interface ICourseInClassService : IBaseService<CourseInClass, CourseInClassViewModel, CourseInClassAddModel, CourseInClassEditModel, CourseInClassFilterModel>
    {
        /// <summary>
        /// Get Course by Class id
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        Task<IEnumerable<CourseViewModel>?> GetCourseByClassId(Guid ClassId);

        /// <summary>
        /// Get Class by Course id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        Task<IEnumerable<ClassViewModel>?> GetClassByCourseId(Guid CourseId);
    }
}
