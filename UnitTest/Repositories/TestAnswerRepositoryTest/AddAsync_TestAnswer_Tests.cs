using API.Data.Entities;
using API.Data.Repositories;
using API.Data.Repositories.Implements;
using API.Data.Repositories.Interfaces;
using Xunit;

namespace UnitTest.Repositories.TestAnswerRepositoryTest
{
    public class AddAsync_TestAnswer_Tests
    {
        private readonly ITestAnswerRepository _repository;
        public AddAsync_TestAnswer_Tests() 
        {
            var dbContext = new MockDbContext().CreateMockDbContext();
            dbContext.TestAnswer.Add(new TestAnswer { TestAnswerId = Guid.Parse("00000000-0000-0000-0000-000000000001") });
            dbContext.TestAnswer.Add(new TestAnswer { TestAnswerId = Guid.Parse("00000000-0000-0000-0000-000000000002") });
            dbContext.SaveChanges();

            var unitOfWork = new UnitOfWork(dbContext);
            _repository = new TestAnswerRepository(dbContext, unitOfWork);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntityAndSaveChanges()
        {
            // Arrange
            var entity = new TestAnswer() { TestAnswerId = Guid.Parse("00000000-0000-0000-0000-000000000003") };

            // Act
            var result = await _repository.AddAsync(entity);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entity, result);
        }

        [Fact]
        public async Task AddRangeAsync_ShouldAddEntitiesAndSaveChanges()
        {
            // Arrange
            var entities = new List<TestAnswer>
            {
                new TestAnswer { TestAnswerId = Guid.Parse("00000000-0000-0000-0000-000000000004") },
                new TestAnswer { TestAnswerId = Guid.Parse("00000000-0000-0000-0000-000000000005") },
                new TestAnswer { TestAnswerId = Guid.Parse("00000000-0000-0000-0000-000000000006") }
            };

            // Act
            var result = await _repository.AddRangeAsync(entities);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entities.Count, result.Count());
            Assert.Equal(entities, result);
        }

        [Fact]
        public async Task AddRangeAsync_ShouldNotAddEntitiesAndNotSaveChanges_WhenNullInput()
        {
            // Arrange
            IEnumerable<TestAnswer> entities = new List<TestAnswer>();

            // Act
            var result = await _repository.AddRangeAsync(entities);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(entities);
        }
    }
}
