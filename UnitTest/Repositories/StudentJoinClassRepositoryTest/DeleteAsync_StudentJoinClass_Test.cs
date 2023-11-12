using API.Data.Entities;
using API.Data.Repositories;
using API.Data.Repositories.Implements;
using API.Data.Repositories.Interfaces;
using Xunit;

namespace UnitTest.Repositories.StudentJoinClassRepositoryTest
{
    public class RemoveAsync_StudentJoinClass_Tests
    {
        private readonly IStudentJoinClassRepository _repository;
        public RemoveAsync_StudentJoinClass_Tests() 
        {
            var dbContext = new MockDbContext().CreateMockDbContext();
            dbContext.StudentJoinClass.Add(new StudentJoinClass { StudentJoinClassId = Guid.Parse("00000000-0000-0000-0000-000000000001") });
            dbContext.StudentJoinClass.Add(new StudentJoinClass { StudentJoinClassId = Guid.Parse("00000000-0000-0000-0000-000000000002") });
            dbContext.SaveChanges();

            var unitOfWork = new UnitOfWork(dbContext);
            _repository = new StudentJoinClassRepository(dbContext, unitOfWork);
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

            var entitiesToRemove = new List<StudentJoinClass> { entityToRemove };

            // Act
            var result = await _repository.RemoveRangeAsync(entitiesToRemove);

            // Assert
            Assert.True(result);
        }
    }
}
