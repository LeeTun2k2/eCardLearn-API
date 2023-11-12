using System.Linq.Expressions;
using API.Commons.Paginations;
using API.Data.Entities;
using API.Data.Repositories;
using API.Data.Repositories.Implements;
using API.Data.Repositories.Interfaces;
using Xunit;

namespace UnitTest.Repositories.FeedbackRepositoryTest
{
    public class GetAsync_Feedback_Tests
    {
        private readonly IFeedbackRepository _repository;
        public GetAsync_Feedback_Tests() 
        {
            var dbContext = new MockDbContext().CreateMockDbContext();
            dbContext.Feedback.Add(new Feedback { FeedbackId = Guid.Parse("00000000-0000-0000-0000-000000000001") });
            dbContext.Feedback.Add(new Feedback { FeedbackId = Guid.Parse("00000000-0000-0000-0000-000000000002") });
            dbContext.SaveChanges();

            var unitOfWork = new UnitOfWork(dbContext);
            _repository = new FeedbackRepository(dbContext, unitOfWork);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnEntities()
        {
            // Arrange
            Expression<Func<Feedback, bool>> filter = null!;
            Func<IQueryable<Feedback>, IOrderedQueryable<Feedback>> orderBy = null!;
            PaginationParameters pagination = null!;

            // Act
            var result = await _repository.GetAsync(filter, orderBy, pagination);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnEntity()
        {
            // Arrange
            Guid entityId = Guid.Parse("00000000-0000-0000-0000-000000000001");

            // Act
            var result = await _repository.GetByIdAsync(entityId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("00000000-0000-0000-0000-000000000001", result.FeedbackId.ToString());
        }

        [Fact]
        public async Task GetByIdAsync_NotReturnEntity()
        {
            // Arrange
            Guid entityId = Guid.Parse("00000000-0000-0000-0000-000000000003");

            // Act
            var result = await _repository.GetByIdAsync(entityId);

            // Assert
            Assert.Null(result);
        }
    }
}
