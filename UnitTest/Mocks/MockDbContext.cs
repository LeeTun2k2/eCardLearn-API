using API.Data;
using API.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class MockDbContext
{
    public DataContext CreateMockDbContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        var dbContext = new DataContext(options);

        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();

        return dbContext;
    }
}
