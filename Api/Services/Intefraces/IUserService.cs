using Api.Models.DTO;

namespace Api.Services.Intefraces
{
    public interface IUserService
    {
        Task<UserDTO> GetUser(string login);

    }
}
