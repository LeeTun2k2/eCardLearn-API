using API.Commons.Paginations;
using API.Data.DTOs.Answer;
using API.Data.DTOs.OpenTriviaDB;
using API.Data.DTOs.Question;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// Question service
    /// </summary>
    public class QuestionService : BaseService<Question, QuestionViewModel, QuestionAddModel, QuestionEditModel, QuestionFilterModel>, IQuestionService
    {
        private new readonly IQuestionRepository _repository;
        private readonly IOpenTriviaDBCategoryRepository _openTriviaDBCategoryRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="openTriviaDBCategoryRepository"></param>
        /// <param name="mapper"></param>
        public QuestionService(IQuestionRepository repository, IOpenTriviaDBCategoryRepository openTriviaDBCategoryRepository, IMapper mapper) 
            : base(repository, mapper)
        {
            _repository = repository;
            _openTriviaDBCategoryRepository = openTriviaDBCategoryRepository;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<QuestionViewModel>?> GetAsync(QuestionFilterModel filter)
        {
            // Default filter condition
            Expression<Func<Question, bool>> filterExpression = p => true; 

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.QuestionString))
                    filterExpression = p => p.QuestionString.Contains(filter.QuestionString);
            }

            // Default orderBy
            Func<IQueryable<Question>, IOrderedQueryable<Question>> orderBy = q => q.OrderBy(p => p.QuestionString); 

            // Define pagination parameters (skip and take)
            PaginationParameters pagination = new ()
            {
                PageNumber = filter?.PageNumber ?? PaginationDefaultValues.PageNumber,
                PageSize = filter?.PageSize ?? PaginationDefaultValues.PageSize
            };

            // Retrieve the data from the repository using the filter, orderBy, and pagination
            var entities = await _repository.GetAsync(filterExpression, orderBy, pagination);

            // Map the retrieved entities to ViewModel
            var models = _mapper.Map<IEnumerable<QuestionViewModel>>(entities);

            return models;
        }

        /// <summary>
        /// Get Question by Course id
        /// </summary>
        /// <param name="CourseId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<QuestionViewModel>> GetByCourseId(Guid CourseId)
        {
            var entities = await _repository.GetByCourseId(CourseId);
            var models = _mapper.Map<IEnumerable<QuestionViewModel>>(entities);
            return models;
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="QuestionId"></param>
        /// <returns></returns>
        public async Task<QuestionViewModel?> GetById(Guid QuestionId)
        {
            var entity = await _repository.GetById(QuestionId);
            var model = _mapper.Map<QuestionViewModel>(entity);
            return model;
        }

        /// <summary>
        /// Generate By Open Trivia DB
        /// </summary>
        /// <param name="OpenTriviaDbCategoryId"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public async Task<IEnumerable<QuestionViewModel>?> GenerateByOpenTriviaDB(Guid OpenTriviaDbCategoryId, int number)
        {
            var category = await _openTriviaDBCategoryRepository.GetByIdAsync(OpenTriviaDbCategoryId);

            if (category == null)
            {
                Console.WriteLine("Category is null.");
                return null;
            }

            var _httpClient = new HttpClient();
            string apiUrl = $"https://opentdb.com/api.php?amount={number}&category={category.OpenTriviaId}&type=multiple";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Response is not successful.");
                return null;
            }

            string jsonResult = await response.Content.ReadAsStringAsync();
            var triviaData = JsonConvert.DeserializeObject<OpenTriviaDBResponse>(jsonResult);

            if (triviaData == null || triviaData.Results == null)
            {
                Console.WriteLine("Data is null");
                return null;
            }

            if (triviaData.Response_Code != 0)
            {
                Console.WriteLine("Can not get data.");
                return null;
            }

            IList<QuestionViewModel> data = new List<QuestionViewModel>();
            foreach (var item in triviaData.Results)
            {
                var question = new QuestionViewModel();
                question.QuestionId = Guid.NewGuid();
                question.QuestionString = item.Question;
                
                var answers = new List<AnswerViewModel>();

                if (item.Incorrect_Answers != null)
                { 
                    foreach (var ans in item.Incorrect_Answers)
                    {
                        var incorrectAns = new AnswerViewModel();
                        incorrectAns.AnswerId = Guid.NewGuid();
                        incorrectAns.AnswerString = ans ?? string.Empty;
                        incorrectAns.IsCorrect = false;
                        incorrectAns.QuestionId = question.QuestionId;

                        answers.Add(incorrectAns);
                    }
                }

                var correctAns = new AnswerViewModel();
                correctAns.AnswerId = Guid.NewGuid();
                correctAns.AnswerString = item.Correct_Answer;
                correctAns.IsCorrect = true;
                correctAns.QuestionId = question.QuestionId;

                Random rnd = new Random();
                int index = rnd.Next(0, 4);

                question.Answers = answers;

                if (index == 3)
                {
                    answers.Add(correctAns);
                }
                else
                {
                    answers.Insert(index, correctAns);
                }

                data.Add(question);
            }

            return data;
        }
    }
}
