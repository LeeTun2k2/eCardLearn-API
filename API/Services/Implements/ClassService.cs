using API.Commons.Paginations;
using API.Data.DTOs.Class;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// Class service
    /// </summary>
    public class ClassService : BaseService<Class, ClassViewModel, ClassAddModel, ClassEditModel, ClassFilterModel>, IClassService
    {
        private new readonly IClassRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public ClassService(IClassRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<ClassViewModel>?> GetAsync(ClassFilterModel filter)
        {
            // Default filter condition
            Expression<Func<Class, bool>> filterExpression = p => true; 

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.ClassName))
                    filterExpression = p => p.ClassName.Contains(filter.ClassName);

                if (!string.IsNullOrEmpty(filter.ClassDescription))
                    filterExpression = p => p.ClassDescription.Contains(filter.ClassDescription);
            }

            // Default orderBy
            Func<IQueryable<Class>, IOrderedQueryable<Class>> orderBy = q => q.OrderBy(p => p.ClassName); 

            // Define pagination parameters (skip and take)
            PaginationParameters pagination = new ()
            {
                PageNumber = filter?.PageNumber ?? PaginationDefaultValues.PageNumber,
                PageSize = filter?.PageSize ?? PaginationDefaultValues.PageSize
            };

            // Retrieve the data from the repository using the filter, orderBy, and pagination
            var entities = await _repository.GetAsync(filterExpression, orderBy, pagination);

            // Map the retrieved entities to ViewModel
            var models = _mapper.Map<IEnumerable<ClassViewModel>>(entities);

            return models;
        }

        /// <summary>
        /// Get Class by Teacher id
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ClassViewModel>> GetByTeacherId(Guid TeacherId)
        {
            var entities = await _repository.GetByTeacherId(TeacherId);
            var models = _mapper.Map<IEnumerable<ClassViewModel>>(entities);
            return models;
        }
    }
}
