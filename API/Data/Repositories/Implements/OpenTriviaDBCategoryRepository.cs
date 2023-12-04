using API.Data.Entities;
using API.Data.Repositories.Interfaces;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// OpenTriviaDBCategory Repository
    /// </summary>
    public class OpenTriviaDBCategoryRepository : BaseRepository<OpenTriviaDBCategory>, IOpenTriviaDBCategoryRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public OpenTriviaDBCategoryRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }
    }
}
