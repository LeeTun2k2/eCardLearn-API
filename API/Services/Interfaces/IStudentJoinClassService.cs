using API.Data.DTOs.StudentJoinClass;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// StudentJoinClass Service Interface
    /// </summary>
    public interface IStudentJoinClassService : IBaseService<StudentJoinClass, StudentJoinClassViewModel, StudentJoinClassAddModel, StudentJoinClassEditModel, StudentJoinClassFilterModel>
    {

    }
}
