using API.Commons.Paginations;
using API.Data.DTOs.Topic;
using API.Data.Entities;
using API.Data.Repositories;
using API.Services.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// Topic service
    /// </summary>
    public class TopicService : BaseService<Topic, TopicViewModel, AnswerAddModel, TopicEditModel, TopicFilterModel>, ITopicService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public TopicService(IBaseRepository<Topic> repository, IMapper mapper) 
            : base(repository, mapper)
        {

        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<TopicViewModel>?> GetAsync(TopicFilterModel filter)
        {
            // Default filter condition
            Expression<Func<Topic, bool>> filterExpression = p => true; 

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.TopicName))
                    filterExpression = p => p.TopicName.Contains(filter.TopicName);

                if (!string.IsNullOrEmpty(filter.TopicDescription))
                    filterExpression = p => p.TopicDescription.Contains(filter.TopicDescription);
            }

            // Default orderBy
            Func<IQueryable<Topic>, IOrderedQueryable<Topic>> orderBy = q => q.OrderBy(p => p.TopicName); 

            // Define pagination parameters (skip and take)
            PaginationParameters pagination = new ()
            {
                PageNumber = filter?.PageNumber ?? PaginationDefaultValues.PageNumber,
                PageSize = filter?.PageSize ?? PaginationDefaultValues.PageSize
            };

            // Retrieve the data from the repository using the filter, orderBy, and pagination
            var entities = await _repository.GetAsync(filterExpression, orderBy, pagination);

            // Map the retrieved entities to ViewModel
            var models = _mapper.Map<IEnumerable<TopicViewModel>>(entities);

            return models;
        }
    }
}
