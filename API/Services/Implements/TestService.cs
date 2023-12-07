using API.Commons.Paginations;
using API.Data.DTOs.Answer;
using API.Data.DTOs.Question;
using API.Data.DTOs.Test;
using API.Data.DTOs.TestResult;
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
        private readonly ITestAnswerRepository _testAnswerRepository;
        private readonly IStudentJoinClassRepository _studentJoinClassRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="testAnswerRepository"></param>
        /// <param name="studentJoinClassRepository"></param>
        /// <param name="mapper"></param>
        public TestService(
            ITestRepository repository, 
            ITestAnswerRepository testAnswerRepository,
            IStudentJoinClassRepository studentJoinClassRepository,
            IMapper mapper) 
            : base(repository, mapper)
        {
            _repository = repository;
            _testAnswerRepository = testAnswerRepository;
            _studentJoinClassRepository = studentJoinClassRepository;
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

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="TestId"></param>
        /// <returns></returns>
        public async Task<TestViewModel?> GetById(Guid TestId)
        {
            var entity = await _repository.GetById(TestId);
            var model = _mapper.Map<TestViewModel>(entity);
            return model;
        }

        /// <summary>
        /// Get Tests by Created User id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TestViewModel>?> GetTestsByCreatedUserId(Guid UserId)
        {
            var entities = await _repository.GetTestsByCreatedUserId(UserId);
            var models = _mapper.Map<IEnumerable<TestViewModel>>(entities);
            return models;
        }

        /// <summary>
        /// Summary Report
        /// </summary>
        /// <param name="TestId"></param>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TestResult_Summary>?> SummaryReport(Guid TestId, Guid? ClassId)
        {
            var testResults = await _testAnswerRepository.Get(TestId);

            if (testResults == null)
            {
                return null;
            }

            if (ClassId != null)
            {
                var studentIds = await _studentJoinClassRepository.GetStudentIdByClassId((Guid)ClassId);

                if (studentIds != null)
                {
                    testResults = testResults.Where(x => studentIds.Contains(x.StudentId));
                }
            }

            var summary = testResults
                .GroupBy(x => x.StudentId)
                .Select(g => new TestResult_Summary
                {
                    FullName = string.Empty,
                    UserId = g.Key,
                    NoCorrectAnswer = g.Where(x => x.Answer!.IsCorrect).Count(),
                    NoIncorrectAnswer = g.Where(x => x.Answer!.IsCorrect== false).Count(),
                })
                .ToList();

            return summary;
        }

        /// <summary>
        /// Detail Report
        /// </summary>
        /// <param name="TestId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TestResult_Detail>?> DetailReport(Guid TestId, Guid UserId)
        {
            var testResults = await _testAnswerRepository.Get(TestId, UserId);

            if (testResults == null)
            {
                return null;
            }

            var details = testResults
                .Select(x => new TestResult_Detail
                {
                    QuestionId = x.QuestionId,
                    Question = _mapper.Map<QuestionViewModel>(x.Question),
                    AnswerId = x.AnswerId,
                    Answer = _mapper.Map<AnswerViewModel>(x.Answer),
                    CorrectAnswerId = x.Question?.Answers?.FirstOrDefault(q => q.IsCorrect)?.AnswerId ?? Guid.Empty,
                    CorrectAnswer = _mapper.Map<AnswerViewModel>(x.Question?.Answers?.FirstOrDefault(q => q.IsCorrect)),
                })
                .ToList();

            return details;
        }
    }
}
