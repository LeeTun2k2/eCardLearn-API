using API.Commons.Paginations;
using API.Data.DTOs.Answer;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// Answer service
    /// </summary>
    public class AnswerService : BaseService<Answer, AnswerViewModel, AnswerAddModel, AnswerEditModel, AnswerFilterModel>, IAnswerService
    {
        private new readonly IAnswerRepository _repository;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public AnswerService(IAnswerRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<AnswerViewModel>?> GetAsync(AnswerFilterModel filter)
        {
            // Default filter condition
            Expression<Func<Answer, bool>> filterExpression = p => true; 

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.AnswerString))
                    filterExpression = p => p.AnswerString.Contains(filter.AnswerString);
            }

            // Default orderBy
            Func<IQueryable<Answer>, IOrderedQueryable<Answer>> orderBy = q => q.OrderBy(p => p.AnswerString); 

            // Define pagination parameters (skip and take)
            PaginationParameters pagination = new ()
            {
                PageNumber = filter?.PageNumber ?? PaginationDefaultValues.PageNumber,
                PageSize = filter?.PageSize ?? PaginationDefaultValues.PageSize
            };

            // Retrieve the data from the repository using the filter, orderBy, and pagination
            var entities = await _repository.GetAsync(filterExpression, orderBy, pagination);

            // Map the retrieved entities to ViewModel
            var models = _mapper.Map<IEnumerable<AnswerViewModel>>(entities);

            return models;
        }

        /// <summary>
        /// Get Answer by Question id
        /// </summary>
        /// <param name="QuestionId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AnswerViewModel>> GetByQuestionId(Guid QuestionId)
        {
            var entities = await _repository.GetByQuestionId(QuestionId);
            var models = _mapper.Map<IEnumerable<AnswerViewModel>>(entities);
            return models;
        }

        /// <summary>
        /// Get Answer by Course id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AnswerViewModel>> GetByCourseId(Guid CourseId)
        {
            var entities = await _repository.GetByCourseId(CourseId);
            var models = _mapper.Map<IEnumerable<AnswerViewModel>>(entities);
            return models;
        }
    }
}
