using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// CourseInClass Repository
    /// </summary>
    public class CourseInClassRepository : BaseRepository<CourseInClass>, ICourseInClassRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public CourseInClassRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }

        /// <summary>
        /// Get Course by Class id
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Course>> GetCourseByClassId(Guid ClassId)
        {
            return await Entities
                .Where(x => x.ClassId == ClassId)
                .Include(x => x.Course)
                .AsNoTracking()
                .Select(x => x.Course!)
                .ToListAsync();
        }

        /// <summary>
        /// Get Class by Course id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Class>> GetClassByCourseId(Guid CourseId)
        {
            return await Entities
                .Where(x => x.CourseId == CourseId)
                .Include(x => x.Class)
                .AsNoTracking()
                .Select(x => x.Class!)
                .ToListAsync();
        }
    }
}
