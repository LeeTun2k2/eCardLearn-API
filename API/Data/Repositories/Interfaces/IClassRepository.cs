using API.Data.Entities;

namespace API.Data.Repositories.Interfaces
{
    /// <summary>
    /// Class
    /// </summary>
    public interface IClassRepository : IBaseRepository<Class>
    {
        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        Task<Class?> GetById(Guid ClassId);

        /// <summary>
        /// Get Class by Teacher id
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        Task<IEnumerable<Class>> GetByTeacherId(Guid TeacherId);
    }
}
