using API.Data.DTOs.Authentication;
using API.Data.DTOs.Class;
using API.Data.DTOs.StudentJoinClass;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// StudentJoinClass Service Interface
    /// </summary>
    public interface IStudentJoinClassService : IBaseService<StudentJoinClass, StudentJoinClassViewModel, StudentJoinClassAddModel, StudentJoinClassEditModel, StudentJoinClassFilterModel>
    {
        /// <summary>
        /// Get Classes by Student id
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        Task<IEnumerable<ClassViewModel>?> GetClassByStudentId(Guid StudentId);

        /// <summary>
        /// Get Student by Class id
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        Task<IEnumerable<UserProfileModel>?> GetStudentByClassId(Guid ClassId);
    }
}
