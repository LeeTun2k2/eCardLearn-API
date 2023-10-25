using API.Data.DTOs.StudentJoinTest;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// StudentJoinTest Service Interface
    /// </summary>
    public interface IStudentJoinTestService : IBaseService<StudentJoinTest, StudentJoinTestViewModel, StudentJoinTestAddModel, StudentJoinTestEditModel, StudentJoinTestFilterModel>
    {

    }
}
