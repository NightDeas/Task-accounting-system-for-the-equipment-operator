using Api.Models.Entities;

namespace Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string login);
    }
}
