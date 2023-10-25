using API.Commons.Paginations;
using API.Data.DTOs.StudentJoinClass;
using API.Data.Entities;
using API.Data.Repositories;
using API.Services.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// StudentJoinClass service
    /// </summary>
    public class StudentJoinClassService : BaseService<StudentJoinClass, StudentJoinClassViewModel, StudentJoinClassAddModel, StudentJoinClassEditModel, StudentJoinClassFilterModel>, IStudentJoinClassService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public StudentJoinClassService(IBaseRepository<StudentJoinClass> repository, IMapper mapper) 
            : base(repository, mapper)
        {

        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<StudentJoinClassViewModel>?> GetAsync(StudentJoinClassFilterModel filter)
        {
            // Default filter condition
            Expression<Func<StudentJoinClass, bool>> filterExpression = p => true;

            if (filter != null)
            {

            }

            // Default orderBy
            Func<IQueryable<StudentJoinClass>, IOrderedQueryable<StudentJoinClass>> orderBy = q => q.OrderBy(q => q.StudentId);

            // Define pagination parameters (skip and take)
            PaginationParameters pagination = new ()
            {
                PageNumber = filter?.PageNumber ?? PaginationDefaultValues.PageNumber,
                PageSize = filter?.PageSize ?? PaginationDefaultValues.PageSize
            };

            // Retrieve the data from the repository using the filter, orderBy, and pagination
            var entities = await _repository.GetAsync(filterExpression, orderBy, pagination);

            // Map the retrieved entities to ViewModel
            var models = _mapper.Map<IEnumerable<StudentJoinClassViewModel>>(entities);

            return models;
        }
    }
}
