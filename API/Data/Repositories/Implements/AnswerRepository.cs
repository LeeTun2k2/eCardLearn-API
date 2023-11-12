using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// Answer Repository
    /// </summary>
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public AnswerRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }

        /// <summary>
        /// Get Answer by Course Id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Answer>> GetByCourseId(Guid CourseId)
        {
            return await Entities
                .Include(x => x.Question)
                .Where(x => x.Question != null && x.Question.CourseId == CourseId)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Get Answer by Question Id
        /// </summary>
        /// <param name="QuestionId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Answer>> GetByQuestionId(Guid QuestionId)
        {
            return await Entities
                .Where(x => x.QuestionId == QuestionId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
