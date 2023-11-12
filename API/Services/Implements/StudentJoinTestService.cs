using API.Commons.Paginations;
using API.Data.DTOs.StudentJoinTest;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// StudentJoinTest service
    /// </summary>
    public class StudentJoinTestService : BaseService<StudentJoinTest, StudentJoinTestViewModel, StudentJoinTestAddModel, StudentJoinTestEditModel, StudentJoinTestFilterModel>, IStudentJoinTestService
    {
        private new readonly IStudentJoinTestRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public StudentJoinTestService(IStudentJoinTestRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<StudentJoinTestViewModel>?> GetAsync(StudentJoinTestFilterModel filter)
        {
            // Default filter condition
            Expression<Func<StudentJoinTest, bool>> filterExpression = p => true; 

            if (filter != null)
            {

            }

            // Default orderBy
            Func<IQueryable<StudentJoinTest>, IOrderedQueryable<StudentJoinTest>> orderBy = q => q.OrderBy(p => p.StudentJoinTestId); 

            // Define pagination parameters (skip and take)
            PaginationParameters pagination = new ()
            {
                PageNumber = filter?.PageNumber ?? PaginationDefaultValues.PageNumber,
                PageSize = filter?.PageSize ?? PaginationDefaultValues.PageSize
            };

            // Retrieve the data from the repository using the filter, orderBy, and pagination
            var entities = await _repository.GetAsync(filterExpression, orderBy, pagination);

            // Map the retrieved entities to ViewModel
            var models = _mapper.Map<IEnumerable<StudentJoinTestViewModel>>(entities);

            return models;
        }
    }
}
