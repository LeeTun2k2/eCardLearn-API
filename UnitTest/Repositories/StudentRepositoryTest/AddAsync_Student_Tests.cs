using API.Data.Entities;
using API.Data.Repositories;
using API.Data.Repositories.Implements;
using API.Data.Repositories.Interfaces;
using Xunit;

namespace UnitTest.Repositories.StudentRepositoryTest
{
    public class AddAsync_Student_Tests
    {
        private readonly IStudentRepository _repository;
        public AddAsync_Student_Tests() 
        {
            var dbContext = new MockDbContext().CreateMockDbContext();
            dbContext.Student.Add(new Student { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "aaaaaaaa" });
            dbContext.Student.Add(new Student { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "bbbbbbbb" });
            dbContext.SaveChanges();

            var unitOfWork = new UnitOfWork(dbContext);
            _repository = new StudentRepository(dbContext, unitOfWork);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntityAndSaveChanges()
        {
            // Arrange
            var entity = new Student() { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "aaaaaaaa" };

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
            var entities = new List<Student>
            {
                new Student { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "aaaaaaaa"  },
                new Student { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "aaaaaaaa"  },
                new Student { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "aaaaaaaa"  }
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
            IEnumerable<Student> entities = new List<Student>();

            // Act
            var result = await _repository.AddRangeAsync(entities);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(entities);
        }
    }
}
