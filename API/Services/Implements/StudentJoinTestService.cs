using API.Commons.Paginations;
using API.Data.DTOs.Authentication;
using API.Data.DTOs.Test;
using API.Data.DTOs.StudentJoinTest;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// StudentJoinTest service
    /// </summary>
    public class StudentJoinTestService : BaseService<StudentJoinTest, StudentJoinTestViewModel, StudentJoinTestAddModel, StudentJoinTestEditModel, StudentJoinTestFilterModel>, IStudentJoinTestService
    {
        private new readonly IStudentJoinTestRepository _repository;
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="userManager"></param>
        /// <param name="mapper"></param>
        public StudentJoinTestService(
            IStudentJoinTestRepository repository, 
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

        /// <summary>
        /// Get Test by Student id
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TestViewModel>?> GetTestByStudentId(Guid StudentId)
        {
            var entities = await _repository.GetTestByStudentId(StudentId);

            var models = _mapper.Map<IEnumerable<TestViewModel>>(entities);

            return models;
        }

        /// <summary>
        /// Get Student by Test id
        /// </summary>
        /// <param name="TestId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserProfileModel>?> GetStudentByTestId(Guid TestId)
        {
            var ids = await _repository.GetStudentIdByTestId(TestId);
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
