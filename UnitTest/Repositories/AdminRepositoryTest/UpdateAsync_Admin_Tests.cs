using API.Data.Entities;
using API.Data.Repositories;
using API.Data.Repositories.Implements;
using API.Data.Repositories.Interfaces;
using Xunit;

namespace UnitTest.Repositories.AdminRepositoryTest
{
    public class UpdateAsync_Admin_Tests
    {
        private readonly IAdminRepository _repository;
        public UpdateAsync_Admin_Tests() 
        {
            var dbContext = new MockDbContext().CreateMockDbContext();
            dbContext.Admin.Add(new Admin { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "aaaaaaaa" });
            dbContext.Admin.Add(new Admin { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "bbbbbbbb" });
            dbContext.SaveChanges();

            var unitOfWork = new UnitOfWork(dbContext);
            _repository = new AdminRepository(dbContext, unitOfWork);
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

            var entities = new List<Admin> { entity };

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
            IEnumerable<Admin> entities = new List<Admin>();

            // Act
            var result = await _repository.UpdateRangeAsync(entities);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(entities);
        }
    }
}
