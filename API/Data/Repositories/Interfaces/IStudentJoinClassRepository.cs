using API.Data.Entities;

namespace API.Data.Repositories.Interfaces
{
    /// <summary>
    /// StudentJoinClass
    /// </summary>
    public interface IStudentJoinClassRepository : IBaseRepository<StudentJoinClass>
    {
        /// <summary>
        /// Get Classes by Student id
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        Task<IEnumerable<Class>> GetClassByStudentId(Guid StudentId);

        /// <summary>
        /// Get Student ids by Class id
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        Task<IEnumerable<Guid>> GetStudentIdByClassId(Guid ClassId);
    }
}
