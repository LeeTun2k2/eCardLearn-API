using API.Commons.Paginations;
using API.Data.DTOs.Test;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// Test service
    /// </summary>
    public class TestService : BaseService<Test, TestViewModel, TestAddModel, TestEditModel, TestFilterModel>, ITestService
    {
        private new readonly ITestRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public TestService(ITestRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<TestViewModel>?> GetAsync(TestFilterModel filter)
        {
            // Default filter condition
            Expression<Func<Test, bool>> filterExpression = p => true; 

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.TestName))
                    filterExpression = p => p.TestName.Contains(filter.TestName);

                if (!string.IsNullOrEmpty(filter.TestDescription))
                    filterExpression = p => p.TestDescription.Contains(filter.TestDescription);
            }

            // Default orderBy
            Func<IQueryable<Test>, IOrderedQueryable<Test>> orderBy = q => q.OrderBy(p => p.TestName); 

            // Define pagination parameters (skip and take)
            PaginationParameters pagination = new ()
            {
                PageNumber = filter?.PageNumber ?? PaginationDefaultValues.PageNumber,
                PageSize = filter?.PageSize ?? PaginationDefaultValues.PageSize
            };

            // Retrieve the data from the repository using the filter, orderBy, and pagination
            var entities = await _repository.GetAsync(filterExpression, orderBy, pagination);

            // Map the retrieved entities to ViewModel
            var models = _mapper.Map<IEnumerable<TestViewModel>>(entities);

            return models;
        }
    }
}
