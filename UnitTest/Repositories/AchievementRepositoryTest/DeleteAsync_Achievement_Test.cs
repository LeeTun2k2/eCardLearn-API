using API.Data.Entities;
using API.Data.Repositories;
using API.Data.Repositories.Implements;
using API.Data.Repositories.Interfaces;
using Xunit;

namespace UnitTest.Repositories.AchievementRepositoryTest
{
    public class RemoveAsync_Achievement_Tests
    {
        private readonly IAchievementRepository _repository;
        public RemoveAsync_Achievement_Tests() 
        {
            var dbContext = new MockDbContext().CreateMockDbContext();
            dbContext.Achievement.Add(new Achievement { AchievementId = Guid.Parse("00000000-0000-0000-0000-000000000001") });
            dbContext.Achievement.Add(new Achievement { AchievementId = Guid.Parse("00000000-0000-0000-0000-000000000002") });
            dbContext.SaveChanges();

            var unitOfWork = new UnitOfWork(dbContext);
            _repository = new AchievementRepository(dbContext, unitOfWork);
        }

        [Fact]
        public async Task RemoveAsync_ShouldRemoveEntity()
        {
            // Arrange
            var entityToRemove = await _repository.GetByIdAsync(Guid.Parse("00000000-0000-0000-0000-000000000001"));

            Assert.NotNull(entityToRemove);

            // Act
            var result = await _repository.RemoveAsync(entityToRemove);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task RemoveRangeAsync_ShouldRemoveEntities()
        {
            // Arrange
            var entityToRemove = await _repository.GetByIdAsync(Guid.Parse("00000000-0000-0000-0000-000000000002"));
            Assert.NotNull(entityToRemove);

            var entitiesToRemove = new List<Achievement> { entityToRemove };

            // Act
            var result = await _repository.RemoveRangeAsync(entitiesToRemove);

            // Assert
            Assert.True(result);
        }
    }
}
