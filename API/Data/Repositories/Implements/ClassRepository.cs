using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// Class Repository
    /// </summary>
    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public ClassRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public async Task<Class?> GetById(Guid ClassId)
        {
            return await Entities
                .Where(x => x.ClassId == ClassId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get Class by Teacher id
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Class>> GetByTeacherId(Guid TeacherId)
        {
            return await Entities
                .Where(x => x.TeacherId == TeacherId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
