﻿using API.Commons.Paginations;
using API.Data.DTOs.Question;
using API.Data.Entities;
using API.Data.Repositories;
using API.Services.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// Question service
    /// </summary>
    public class QuestionService : BaseService<Question, QuestionViewModel, QuestionAddModel, QuestionEditModel, QuestionFilterModel>, IQuestionService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public QuestionService(IBaseRepository<Question> repository, IMapper mapper) 
            : base(repository, mapper)
        {

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
    }
}
