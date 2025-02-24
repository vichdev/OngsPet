namespace OngsPet.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        public Task<bool> ExistUserWithSameEmail(string email);
    }
}
