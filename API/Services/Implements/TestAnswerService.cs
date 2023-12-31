﻿using API.Commons.Paginations;
using API.Data.DTOs.TestAnswer;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// TestAnswer service
    /// </summary>
    public class TestAnswerService : BaseService<TestAnswer, TestAnswerViewModel, TestAnswerAddModel, TestAnswerEditModel, TestAnswerFilterModel>, ITestAnswerService
    {
        private new readonly ITestAnswerRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public TestAnswerService(ITestAnswerRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<TestAnswerViewModel>?> GetAsync(TestAnswerFilterModel filter)
        {
            // Default filter condition
            Expression<Func<TestAnswer, bool>> filterExpression = p => true; 

            if (filter != null)
            {
                
            }

            // Default orderBy
            Func<IQueryable<TestAnswer>, IOrderedQueryable<TestAnswer>> orderBy = q => q.OrderBy(p => p.TestAnswerId); 

            // Define pagination parameters (skip and take)
            PaginationParameters pagination = new ()
            {
                PageNumber = filter?.PageNumber ?? PaginationDefaultValues.PageNumber,
                PageSize = filter?.PageSize ?? PaginationDefaultValues.PageSize
            };

            // Retrieve the data from the repository using the filter, orderBy, and pagination
            var entities = await _repository.GetAsync(filterExpression, orderBy, pagination);

            // Map the retrieved entities to ViewModel
            var models = _mapper.Map<IEnumerable<TestAnswerViewModel>>(entities);

            return models;
        }
    }
}
