using OngsPet.Domain.Repositories;

namespace OngsPet.Infrastructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OngsPetDbContext _dbContext;
        public UnitOfWork(OngsPetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
