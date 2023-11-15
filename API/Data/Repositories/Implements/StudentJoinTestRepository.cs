using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// StudentJoinTest Repository
    /// </summary>
    public class StudentJoinTestRepository : BaseRepository<StudentJoinTest>, IStudentJoinTestRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public StudentJoinTestRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }

        /// <summary>
        /// Get Testes by Student id
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
    }
}
