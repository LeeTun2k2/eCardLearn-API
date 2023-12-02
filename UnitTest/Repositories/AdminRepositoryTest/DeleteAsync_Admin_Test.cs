using API.Data.Entities;
using API.Data.Repositories;
using API.Data.Repositories.Implements;
using API.Data.Repositories.Interfaces;
using Xunit;

namespace UnitTest.Repositories.AdminRepositoryTest
{
    public class RemoveAsync_Admin_Tests
    {
        private readonly IAdminRepository _repository;
        public RemoveAsync_Admin_Tests() 
        {
            var dbContext = new MockDbContext().CreateMockDbContext();
            dbContext.Admin.Add(new Admin { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "aaaaaaaa" });
            dbContext.Admin.Add(new Admin { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "bbbbbbbb" });
            dbContext.SaveChanges();

            var unitOfWork = new UnitOfWork(dbContext);
            _repository = new AdminRepository(dbContext, unitOfWork);
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

            var entitiesToRemove = new List<Admin> { entityToRemove };

            // Act
            var result = await _repository.RemoveRangeAsync(entitiesToRemove);

            // Assert
            Assert.True(result);
        }
    }
}
