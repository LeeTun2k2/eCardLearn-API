using API.Data.DTOs.Class;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Class Service Interface
    /// </summary>
    public interface IClassService : IBaseService<Class, ClassViewModel, ClassAddModel, ClassEditModel, ClassFilterModel>
    {
        /// <summary>
        /// Get Class by Teacher id
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        Task<IEnumerable<ClassViewModel>> GetByTeacherId(Guid TeacherId);
    }
}
