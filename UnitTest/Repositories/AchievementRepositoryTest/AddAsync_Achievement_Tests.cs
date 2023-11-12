using API.Data.Entities;
using API.Data.Repositories;
using API.Data.Repositories.Implements;
using API.Data.Repositories.Interfaces;
using Xunit;

namespace UnitTest.Repositories.AchievementRepositoryTest
{
    public class AddAsync_Achievement_Tests
    {
        private readonly IAchievementRepository _repository;
        public AddAsync_Achievement_Tests() 
        {
            var dbContext = new MockDbContext().CreateMockDbContext();
            dbContext.Achievement.Add(new Achievement { AchievementId = Guid.Parse("00000000-0000-0000-0000-000000000001") });
            dbContext.Achievement.Add(new Achievement { AchievementId = Guid.Parse("00000000-0000-0000-0000-000000000002") });
            dbContext.SaveChanges();

            var unitOfWork = new UnitOfWork(dbContext);
            _repository = new AchievementRepository(dbContext, unitOfWork);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntityAndSaveChanges()
        {
            // Arrange
            var entity = new Achievement() { AchievementId = Guid.Parse("00000000-0000-0000-0000-000000000003") };

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
            var entities = new List<Achievement>
            {
                new Achievement { AchievementId = Guid.Parse("00000000-0000-0000-0000-000000000004") },
                new Achievement { AchievementId = Guid.Parse("00000000-0000-0000-0000-000000000005") },
                new Achievement { AchievementId = Guid.Parse("00000000-0000-0000-0000-000000000006") }
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
            IEnumerable<Achievement> entities = new List<Achievement>();

            // Act
            var result = await _repository.AddRangeAsync(entities);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(entities);
        }
    }
}
