using API.Data.Entities;
using API.Data.Repositories;
using API.Data.Repositories.Implements;
using API.Data.Repositories.Interfaces;
using Xunit;

namespace UnitTest.Repositories.TeacherRepositoryTest
{
    public class AddAsync_Teacher_Tests
    {
        private readonly ITeacherRepository _repository;
        public AddAsync_Teacher_Tests() 
        {
            var dbContext = new MockDbContext().CreateMockDbContext();
            dbContext.Teacher.Add(new Teacher { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "aaaaaaaa" });
            dbContext.Teacher.Add(new Teacher { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "bbbbbbbb" });
            dbContext.SaveChanges();

            var unitOfWork = new UnitOfWork(dbContext);
            _repository = new TeacherRepository(dbContext, unitOfWork);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntityAndSaveChanges()
        {
            // Arrange
            var entity = new Teacher() { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "aaaaaaaa" };

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
            var entities = new List<Teacher>
            {
                new Teacher { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "aaaaaaaa"  },
                new Teacher { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "aaaaaaaa"  },
                new Teacher { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "aaaaaaaa"  }
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
            IEnumerable<Teacher> entities = new List<Teacher>();

            // Act
            var result = await _repository.AddRangeAsync(entities);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(entities);
        }
    }
}
