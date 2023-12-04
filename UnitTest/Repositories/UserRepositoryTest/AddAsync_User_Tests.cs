using API.Data.Entities;
using API.Data.Repositories;
using API.Data.Repositories.Implements;
using API.Data.Repositories.Interfaces;
using Xunit;

namespace UnitTest.Repositories.UserRepositoryTest
{
    public class AddAsync_User_Tests
    {
        private readonly IUserRepository _repository;
        public AddAsync_User_Tests() 
        {
            var dbContext = new MockDbContext().CreateMockDbContext();
            dbContext.User.Add(new User { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "aaaaaaaa" });
            dbContext.User.Add(new User { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "bbbbbbbb" });
            dbContext.SaveChanges();

            var unitOfWork = new UnitOfWork(dbContext);
            _repository = new UserRepository(dbContext, unitOfWork);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntityAndSaveChanges()
        {
            // Arrange
            var entity = new User() { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "aaaaaaaa" };

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
            var entities = new List<User>
            {
                new User { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "aaaaaaaa"  },
                new User { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "aaaaaaaa"  },
                new User { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "aaaaaaaa"  }
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
            IEnumerable<User> entities = new List<User>();

            // Act
            var result = await _repository.AddRangeAsync(entities);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(entities);
        }
    }
}
