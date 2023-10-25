using API.Data.DTOs.Test;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Test Service Interface
    /// </summary>
    public interface ITestService : IBaseService<Test, TestViewModel, TestAddModel, TestEditModel, TestFilterModel>
    {

    }
}
