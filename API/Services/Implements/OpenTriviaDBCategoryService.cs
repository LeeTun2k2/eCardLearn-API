using API.Commons.Paginations;
using API.Data.DTOs.OpenTriviaDBCategory;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// OpenTriviaDBCategory service
    /// </summary>
    public class OpenTriviaDBCategoryService : BaseService<OpenTriviaDBCategory, OpenTriviaDBCategoryViewModel, OpenTriviaDBCategoryAddModel, OpenTriviaDBCategoryEditModel, OpenTriviaDBCategoryFilterModel>, IOpenTriviaDBCategoryService
    {
        private new readonly IOpenTriviaDBCategoryRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public OpenTriviaDBCategoryService(IOpenTriviaDBCategoryRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<OpenTriviaDBCategoryViewModel>?> GetAsync(OpenTriviaDBCategoryFilterModel filter)
        {
            // Default filter condition
            Expression<Func<OpenTriviaDBCategory, bool>> filterExpression = p => true; 

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.CategoryName))
                    filterExpression = p => p.CategoryName.Contains(filter.CategoryName);
            }

            // Default orderBy
            Func<IQueryable<OpenTriviaDBCategory>, IOrderedQueryable<OpenTriviaDBCategory>> orderBy = q => q.OrderBy(p => p.CategoryName); 

            // Define pagination parameters (skip and take)
            PaginationParameters pagination = new ()
            {
                PageNumber = filter?.PageNumber ?? PaginationDefaultValues.PageNumber,
                PageSize = filter?.PageSize ?? PaginationDefaultValues.PageSize
            };

            // Retrieve the data from the repository using the filter, orderBy, and pagination
            var entities = await _repository.GetAsync(filterExpression, orderBy, pagination);

            // Map the retrieved entities to ViewModel
            var models = _mapper.Map<IEnumerable<OpenTriviaDBCategoryViewModel>>(entities);

            return models;
        }
    }
}
