using API.Commons.Paginations;
using API.Data.DTOs.Course;
using API.Data.Entities;
using API.Data.Repositories;
using API.Services.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// Course service
    /// </summary>
    public class CourseService : BaseService<Course, CourseViewModel, CourseAddModel, CourseEditModel, CourseFilterModel>, ICourseService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public CourseService(IBaseRepository<Course> repository, IMapper mapper) 
            : base(repository, mapper)
        {

        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<CourseViewModel>?> GetAsync(CourseFilterModel filter)
        {
            // Default filter condition
            Expression<Func<Course, bool>> filterExpression = p => true; 

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.CourseName))
                    filterExpression = p => p.CourseName.Contains(filter.CourseName);

                if (!string.IsNullOrEmpty(filter.CourseDescription))
                    filterExpression = p => p.CourseDescription.Contains(filter.CourseDescription);
            }

            // Default orderBy
            Func<IQueryable<Course>, IOrderedQueryable<Course>> orderBy = q => q.OrderBy(p => p.CourseName); 

            // Define pagination parameters (skip and take)
            PaginationParameters pagination = new ()
            {
                PageNumber = filter?.PageNumber ?? PaginationDefaultValues.PageNumber,
                PageSize = filter?.PageSize ?? PaginationDefaultValues.PageSize
            };

            // Retrieve the data from the repository using the filter, orderBy, and pagination
            var entities = await _repository.GetAsync(filterExpression, orderBy, pagination);

            // Map the retrieved entities to ViewModel
            var models = _mapper.Map<IEnumerable<CourseViewModel>>(entities);

            return models;
        }
    }
}
