using Microsoft.EntityFrameworkCore;
using OngsPet.Domain.Entities;
using OngsPet.Domain.Repositories.User;

namespace OngsPet.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {

        private readonly OngsPetDbContext _dbContext;

        public UserRepository(OngsPetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task<bool> ExistUserWithSameEmail(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email.Equals(email));
        }
    }
}
