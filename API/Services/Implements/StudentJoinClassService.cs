using API.Commons.Paginations;
using API.Data.DTOs.Authentication;
using API.Data.DTOs.Class;
using API.Data.DTOs.StudentJoinClass;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using MailKit.Search;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// StudentJoinClass service
    /// </summary>
    public class StudentJoinClassService : BaseService<StudentJoinClass, StudentJoinClassViewModel, StudentJoinClassAddModel, StudentJoinClassEditModel, StudentJoinClassFilterModel>, IStudentJoinClassService
    {
        private new readonly IStudentJoinClassRepository _repository;
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="userManager"></param>
        /// <param name="mapper"></param>
        public StudentJoinClassService(
            IStudentJoinClassRepository repository,
            UserManager<User> userManager,
            IMapper mapper) 
            : base(repository, mapper)
        {
            _repository = repository;
            _userManager = userManager;
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

        /// <summary>
        /// Get Class by Student id
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ClassViewModel>?> GetClassByStudentId(Guid StudentId)
        {
            var entities = await _repository.GetClassByStudentId(StudentId);

            var models = _mapper.Map<IEnumerable<ClassViewModel>>(entities);

            return models;
        }

        /// <summary>
        /// Get Student by Class id
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserProfileModel>?> GetStudentByClassId(Guid ClassId)
        {
            var ids = await _repository.GetStudentIdByClassId(ClassId);

            var models = new List<User>();

            foreach (var id in ids)
            {
                var user = await _userManager.FindByIdAsync(id.ToString());

                if (user != null)
                    models.Add(user);
            }

            var data = _mapper.Map<IEnumerable<UserProfileModel>>(models);

            return data;
        }
    }
}
