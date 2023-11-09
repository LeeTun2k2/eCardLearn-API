using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// Course Repository
    /// </summary>
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public CourseRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }

        /// <summary>
        /// Get Course by Teacher id
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Course>> GetByTeacherId(Guid TeacherId)
        {
            return await Entities
                .Where(x => x.TeacherId == TeacherId)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Get Course by Topic id
        /// </summary>
        /// <param name="TopicId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Course>> GetByTopicId(Guid TopicId)
        {
            return await Entities
                .Where(x => x.TopicId == TopicId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
