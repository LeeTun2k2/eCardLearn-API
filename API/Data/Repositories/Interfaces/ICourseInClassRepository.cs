using API.Data.Entities;

namespace API.Data.Repositories.Interfaces
{
    /// <summary>
    /// CourseInClass
    /// </summary>
    public interface ICourseInClassRepository : IBaseRepository<CourseInClass>
    {
        /// <summary>
        /// Get Course by Class id
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        Task<IEnumerable<Course>> GetCourseByClassId(Guid ClassId);

        /// <summary>
        /// Get Class ids by Course id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        Task<IEnumerable<Class>> GetClassByCourseId(Guid CourseId);
    }
}
