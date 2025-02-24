

namespace OngsPet.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}
