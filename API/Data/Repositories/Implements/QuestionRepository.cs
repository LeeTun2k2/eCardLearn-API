using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// Question Repository
    /// </summary>
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public QuestionRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }

        /// <summary>
        /// Get Question by Course id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Question>> GetByCourseId(Guid CourseId)
        {
            return await Entities
                .Where(x => x.CourseId == CourseId)
                .Include(x => x.Answers)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Get Question by Id
        /// </summary>
        /// <param name="QuestionId"></param>
        /// <returns></returns>
        public async Task<Question?> GetById(Guid QuestionId)
        {
            return await Entities
                .Where(x => x.QuestionId == QuestionId)
                .Include(x => x.Answers)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
