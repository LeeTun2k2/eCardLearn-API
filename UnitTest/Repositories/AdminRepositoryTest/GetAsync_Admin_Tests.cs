using System.Linq.Expressions;
using API.Commons.Paginations;
using API.Data.Entities;
using API.Data.Repositories;
using API.Data.Repositories.Implements;
using API.Data.Repositories.Interfaces;
using Xunit;

namespace UnitTest.Repositories.AdminRepositoryTest
{
    public class GetAsync_Admin_Tests
    {
        private readonly IAdminRepository _repository;
        public GetAsync_Admin_Tests() 
        {
            var dbContext = new MockDbContext().CreateMockDbContext();
            dbContext.Admin.Add(new Admin { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "aaaaaaaa" });
            dbContext.Admin.Add(new Admin { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "bbbbbbbb" });
            dbContext.SaveChanges();

            var unitOfWork = new UnitOfWork(dbContext);
            _repository = new AdminRepository(dbContext, unitOfWork);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnEntities()
        {
            // Arrange
            Expression<Func<Admin, bool>> filter = null!;
            Func<IQueryable<Admin>, IOrderedQueryable<Admin>> orderBy = null!;
            PaginationParameters pagination = null!;

            // Act
            var result = await _repository.GetAsync(filter, orderBy, pagination);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnEntity()
        {
            // Arrange
            Guid entityId = Guid.Parse("00000000-0000-0000-0000-000000000001");

            // Act
            var result = await _repository.GetByIdAsync(entityId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("00000000-0000-0000-0000-000000000001", result.Id.ToString());
        }

        [Fact]
        public async Task GetByIdAsync_NotReturnEntity()
        {
            // Arrange
            Guid entityId = Guid.Parse("00000000-0000-0000-0000-000000000003");

            // Act
            var result = await _repository.GetByIdAsync(entityId);

            // Assert
            Assert.Null(result);
        }
    }
}
