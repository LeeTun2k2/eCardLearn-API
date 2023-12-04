using System.Linq.Expressions;
using API.Commons.Paginations;
using API.Data.Entities;
using API.Data.Repositories;
using API.Data.Repositories.Implements;
using API.Data.Repositories.Interfaces;
using Xunit;

namespace UnitTest.Repositories.UserLoginHistoryRepositoryTest
{
    public class GetAsync_UserLoginHistory_Tests
    {
        private readonly IUserLoginHistoryRepository _repository;
        public GetAsync_UserLoginHistory_Tests() 
        {
            var dbContext = new MockDbContext().CreateMockDbContext();
            dbContext.UserLoginHistory.Add(new UserLoginHistory { UserLoginHistoryId = Guid.Parse("00000000-0000-0000-0000-000000000001") });
            dbContext.UserLoginHistory.Add(new UserLoginHistory { UserLoginHistoryId = Guid.Parse("00000000-0000-0000-0000-000000000002") });
            dbContext.SaveChanges();

            var unitOfWork = new UnitOfWork(dbContext);
            _repository = new UserLoginHistoryRepository(dbContext, unitOfWork);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnEntities()
        {
            // Arrange
            Expression<Func<UserLoginHistory, bool>> filter = null!;
            Func<IQueryable<UserLoginHistory>, IOrderedQueryable<UserLoginHistory>> orderBy = null!;
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
            Assert.Equal("00000000-0000-0000-0000-000000000001", result.UserLoginHistoryId.ToString());
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
