using API.Commons.Paginations;
using API.Data.DTOs.Authentication;
using API.Data.DTOs.Class;
using API.Data.DTOs.Course;
using API.Data.DTOs.CourseInClass;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// CourseInClass service
    /// </summary>
    public class CourseInClassService : BaseService<CourseInClass, CourseInClassViewModel, CourseInClassAddModel, CourseInClassEditModel, CourseInClassFilterModel>, ICourseInClassService
    {
        private new readonly ICourseInClassRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public CourseInClassService(
            ICourseInClassRepository repository, 
            IMapper mapper) 
            : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<CourseInClassViewModel>?> GetAsync(CourseInClassFilterModel filter)
        {
            // Default filter condition
            Expression<Func<CourseInClass, bool>> filterExpression = p => true; 

            if (filter != null)
            {

            }

            // Default orderBy
            Func<IQueryable<CourseInClass>, IOrderedQueryable<CourseInClass>> orderBy = q => q.OrderBy(p => p.CourseInClassId); 

            // Define pagination parameters (skip and take)
            PaginationParameters pagination = new ()
            {
                PageNumber = filter?.PageNumber ?? PaginationDefaultValues.PageNumber,
                PageSize = filter?.PageSize ?? PaginationDefaultValues.PageSize
            };

            // Retrieve the data from the repository using the filter, orderBy, and pagination
            var entities = await _repository.GetAsync(filterExpression, orderBy, pagination);

            // Map the retrieved entities to ViewModel
            var models = _mapper.Map<IEnumerable<CourseInClassViewModel>>(entities);

            return models;
        }

        /// <summary>
        /// Get Course by Class id
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CourseViewModel>?> GetCourseByClassId(Guid ClassId)
        {
            var entities = await _repository.GetCourseByClassId(ClassId);

            var models = _mapper.Map<IEnumerable<CourseViewModel>>(entities);

            return models;
        }

        /// <summary>
        /// Get Class by Course id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ClassViewModel>?> GetClassByCourseId(Guid CourseId)
        {
            var entities = await _repository.GetClassByCourseId(CourseId);

            var models = _mapper.Map<IEnumerable<ClassViewModel>>(entities);

            return models;
        }
    }
}
