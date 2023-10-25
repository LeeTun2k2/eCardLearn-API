using API.Data.Entities;
using API.Data.Repositories.Interfaces;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// Topic Repository
    /// </summary>
    public class TopicRepository : BaseRepository<Topic>, ITopicRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public TopicRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }
    }
}
