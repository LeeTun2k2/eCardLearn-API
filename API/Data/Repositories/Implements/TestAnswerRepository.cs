using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// TestAnswer Repository
    /// </summary>
    public class TestAnswerRepository : BaseRepository<TestAnswer>, ITestAnswerRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public TestAnswerRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }

        /// <summary>
        /// Get Tests by Student id
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Test>> GetTestByStudentId(Guid StudentId)
        {
            return await Entities
                .Where(x => x.StudentId == StudentId)
                .Include(x => x.Test)
                .AsNoTracking()
                .Select(x => x.Test!)
                .ToListAsync();
        }

        /// <summary>
        /// Get Student ids by Test id
        /// </summary>
        /// <param name="TestId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Guid>> GetStudentIdByTestId(Guid TestId)
        {
            return await Entities
                .Where(x => x.TestId == TestId)
                .AsNoTracking()
                .Select(x => x.StudentId)
                .ToListAsync();
        }

        /// <summary>
        /// Get Student ids by Test id
        /// </summary>
        /// <param name="TestId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TestAnswer>?> Get(Guid TestId)
        {
            return await Entities
                .Where(x => x.TestId == TestId)
                .Include(x => x.Question!)
                .ThenInclude(x => x.Answers)
                .Include(x => x.Answer)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Get Student ids by Test id
        /// </summary>
        /// <param name="TestId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TestAnswer>?> Get(Guid TestId, Guid UserId)
        {
            return await Entities
                .Where(x => x.TestId == TestId)
                .Where(x => x.StudentId == UserId)
                .Include(x => x.Question!)
                .ThenInclude(x => x.Answers)
                .Include(x => x.Answer)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
