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
        /// Get By Id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public async Task<Course?> GetById(Guid CourseId)
        {
            return await Entities
                .Where(x => x.CourseId == CourseId)
                .Include(x => x.Topic)
                .Include(x => x.Questions)
                .AsNoTracking()
                .FirstOrDefaultAsync();
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
                .Include(x => x.Topic)
                .Include(x => x.Questions)
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
                .Include(x => x.Topic)
                .Include(x => x.Questions)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
