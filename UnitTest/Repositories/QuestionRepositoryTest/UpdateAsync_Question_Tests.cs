using API.Data.Entities;
using API.Data.Repositories;
using API.Data.Repositories.Implements;
using API.Data.Repositories.Interfaces;
using Xunit;

namespace UnitTest.Repositories.QuestionRepositoryTest
{
    public class UpdateAsync_Question_Tests
    {
        private readonly IQuestionRepository _repository;
        public UpdateAsync_Question_Tests() 
        {
            var dbContext = new MockDbContext().CreateMockDbContext();
            dbContext.Question.Add(new Question { QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001") });
            dbContext.Question.Add(new Question { QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000002") });
            dbContext.SaveChanges();

            var unitOfWork = new UnitOfWork(dbContext);
            _repository = new QuestionRepository(dbContext, unitOfWork);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateEntityAndSaveChanges()
        {
            // Arrange
            var entity = await _repository.GetByIdAsync(Guid.Parse("00000000-0000-0000-0000-000000000001"));
            Assert.NotNull(entity);

            // Act
            var result = await _repository.UpdateAsync(entity);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entity, result);
        }

        [Fact]
        public async Task UpdateRangeAsync_ShouldUpdateEntitiesAndSaveChanges()
        {
            // Arrange
            var entity = await _repository.GetByIdAsync(Guid.Parse("00000000-0000-0000-0000-000000000001"));
            Assert.NotNull(entity);

            var entities = new List<Question> { entity };

            // Act
            var result = await _repository.UpdateRangeAsync(entities);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entities.Count, result.Count());
            Assert.Equal(entities, result);
        }

        [Fact]
        public async Task UpdateRangeAsync_ShouldNotUpdateEntitiesAndNotSaveChanges_WhenNullInput()
        {
            // Arrange
            IEnumerable<Question> entities = new List<Question>();

            // Act
            var result = await _repository.UpdateRangeAsync(entities);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(entities);
        }
    }
}
