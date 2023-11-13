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
        /// Get By Id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        Task<CourseViewModel?> GetById(Guid CourseId);

        /// <summary>
        /// Get Course by Teacher id
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        Task<IEnumerable<CourseViewModel>> GetByTeacherId(Guid TeacherId);

        /// <summary>
        /// Get Course by Topic id
        /// </summary>
        /// <param name="TopicId"></param>
        /// <returns></returns>
        Task<IEnumerable<CourseViewModel>> GetByTopicId(Guid TopicId);
    }
}
