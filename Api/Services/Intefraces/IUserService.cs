using Api.Models.DTO;

namespace Api.Services.Intefraces
{
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        //Task<UserDTO> GetUser(string login);
        /// <summary>
        /// Получить текущего пользователя
        /// </summary>
        /// <returns></returns>
        Task<UserDTO> GetCurrentUser();
    }
}
