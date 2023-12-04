using API.Data.DTOs.OpenTriviaDBCategory;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// OpenTriviaDBCategory Service Interface
    /// </summary>
    public interface IOpenTriviaDBCategoryService : IBaseService<OpenTriviaDBCategory, OpenTriviaDBCategoryViewModel, OpenTriviaDBCategoryAddModel, OpenTriviaDBCategoryEditModel, OpenTriviaDBCategoryFilterModel>
    {

    }
}
