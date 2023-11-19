using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// Test Repository
    /// </summary>
    public class TestRepository : BaseRepository<Test>, ITestRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public TestRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="TestId"></param>
        /// <returns></returns>
        public async Task<Test?> GetById(Guid TestId)
        {
            return await Entities
                .Where(x => x.TestId == TestId)
                .Include(x => x.Course!)
                .ThenInclude(x => x.Questions!)
                .ThenInclude(x => x.Answers)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
