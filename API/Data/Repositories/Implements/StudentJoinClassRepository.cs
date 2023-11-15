using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// StudentJoinClass Repository
    /// </summary>
    public class StudentJoinClassRepository : BaseRepository<StudentJoinClass>, IStudentJoinClassRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public StudentJoinClassRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }

        /// <summary>
        /// Get Classes by Student id
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Class>> GetClassByStudentId(Guid StudentId)
        {
            return await Entities
                .Where(x => x.StudentId == StudentId)
                .Include(x => x.Class)
                .AsNoTracking()
                .Select(x => x.Class!)
                .ToListAsync();
        }

        /// <summary>
        /// Get Student ids by Class id
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Guid>> GetStudentIdByClassId(Guid ClassId)
        {
            return await Entities
                .Where(x => x.ClassId == ClassId)
                .AsNoTracking()
                .Select(x => x.StudentId)
                .ToListAsync();
        }
    }
}
