using API.Data.Entities;
using API.Data.Repositories;
using API.Data.Repositories.Implements;
using API.Data.Repositories.Interfaces;
using Xunit;

namespace UnitTest.Repositories.StudentJoinClassRepositoryTest
{
    public class AddAsync_StudentJoinClass_Tests
    {
        private readonly IStudentJoinClassRepository _repository;
        public AddAsync_StudentJoinClass_Tests() 
        {
            var dbContext = new MockDbContext().CreateMockDbContext();
            dbContext.StudentJoinClass.Add(new StudentJoinClass { StudentJoinClassId = Guid.Parse("00000000-0000-0000-0000-000000000001") });
            dbContext.StudentJoinClass.Add(new StudentJoinClass { StudentJoinClassId = Guid.Parse("00000000-0000-0000-0000-000000000002") });
            dbContext.SaveChanges();

            var unitOfWork = new UnitOfWork(dbContext);
            _repository = new StudentJoinClassRepository(dbContext, unitOfWork);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntityAndSaveChanges()
        {
            // Arrange
            var entity = new StudentJoinClass() { StudentJoinClassId = Guid.Parse("00000000-0000-0000-0000-000000000003") };

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
            var entities = new List<StudentJoinClass>
            {
                new StudentJoinClass { StudentJoinClassId = Guid.Parse("00000000-0000-0000-0000-000000000004") },
                new StudentJoinClass { StudentJoinClassId = Guid.Parse("00000000-0000-0000-0000-000000000005") },
                new StudentJoinClass { StudentJoinClassId = Guid.Parse("00000000-0000-0000-0000-000000000006") }
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
            IEnumerable<StudentJoinClass> entities = new List<StudentJoinClass>();

            // Act
            var result = await _repository.AddRangeAsync(entities);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(entities);
        }
    }
}
