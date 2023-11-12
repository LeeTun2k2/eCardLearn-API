using API.Data.Entities;
using API.Data.Repositories;
using API.Data.Repositories.Implements;
using API.Data.Repositories.Interfaces;
using Xunit;

namespace UnitTest.Repositories.TopicRepositoryTest
{
    public class AddAsync_Topic_Tests
    {
        private readonly ITopicRepository _repository;
        public AddAsync_Topic_Tests() 
        {
            var dbContext = new MockDbContext().CreateMockDbContext();
            dbContext.Topic.Add(new Topic { TopicId = Guid.Parse("00000000-0000-0000-0000-000000000001") });
            dbContext.Topic.Add(new Topic { TopicId = Guid.Parse("00000000-0000-0000-0000-000000000002") });
            dbContext.SaveChanges();

            var unitOfWork = new UnitOfWork(dbContext);
            _repository = new TopicRepository(dbContext, unitOfWork);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntityAndSaveChanges()
        {
            // Arrange
            var entity = new Topic() { TopicId = Guid.Parse("00000000-0000-0000-0000-000000000003") };

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
            var entities = new List<Topic>
            {
                new Topic { TopicId = Guid.Parse("00000000-0000-0000-0000-000000000004") },
                new Topic { TopicId = Guid.Parse("00000000-0000-0000-0000-000000000005") },
                new Topic { TopicId = Guid.Parse("00000000-0000-0000-0000-000000000006") }
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
            IEnumerable<Topic> entities = new List<Topic>();

            // Act
            var result = await _repository.AddRangeAsync(entities);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(entities);
        }
    }
}
