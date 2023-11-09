using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// Feedback Repository
    /// </summary>
    public class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public FeedbackRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }

        /// <summary>
        /// Get Feedback by Course id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Feedback>> GetByCourseId(Guid CourseId)
        {
            return await Entities
                .Where(x => x.CourseId == CourseId)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Get Feedback by User id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Feedback>> GetByUserId(Guid UserId)
        {
            return await Entities
                .Where(x => x.UserId == UserId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
