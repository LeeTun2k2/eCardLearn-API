using API.Commons.Paginations;
using API.Data.DTOs.Feedback;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// Feedback service
    /// </summary>
    public class FeedbackService : BaseService<Feedback, FeedbackViewModel, FeedbackAddModel, FeedbackEditModel, FeedbackFilterModel>, IFeedbackService
    {
        private new readonly IFeedbackRepository _repository;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public FeedbackService(IFeedbackRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<FeedbackViewModel>?> GetAsync(FeedbackFilterModel filter)
        {
            // Default filter condition
            Expression<Func<Feedback, bool>> filterExpression = p => true; 

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Title))
                    filterExpression = p => p.Title.Contains(filter.Title);

                if (!string.IsNullOrEmpty(filter.Description))
                    filterExpression = p => p.Description.Contains(filter.Description);

                if (1 <= filter.Rating && filter.Rating <= 5)
                    filterExpression = p => p.Rating.Equals(filter.Rating);
            }

            // Default orderBy
            Func<IQueryable<Feedback>, IOrderedQueryable<Feedback>> orderBy = q => q.OrderBy(p => p.Title); 

            // Define pagination parameters (skip and take)
            PaginationParameters pagination = new ()
            {
                PageNumber = filter?.PageNumber ?? PaginationDefaultValues.PageNumber,
                PageSize = filter?.PageSize ?? PaginationDefaultValues.PageSize
            };

            // Retrieve the data from the repository using the filter, orderBy, and pagination
            var entities = await _repository.GetAsync(filterExpression, orderBy, pagination);

            // Map the retrieved entities to ViewModel
            var models = _mapper.Map<IEnumerable<FeedbackViewModel>>(entities);

            return models;
        }

        /// <summary>
        /// Get Feedback by User id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<FeedbackViewModel>> GetByUserId(Guid UserId)
        {
            var entities = await _repository.GetByUserId(UserId);
            var models = _mapper.Map<IEnumerable<FeedbackViewModel>>(entities);
            return models;
        }

        /// <summary>
        /// Get Feedback by Course id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<FeedbackViewModel>> GetByCourseId(Guid CourseId)
        {
            var entities = await _repository.GetByCourseId(CourseId);
            var models = _mapper.Map<IEnumerable<FeedbackViewModel>>(entities);
            return models;
        }
    }
}
