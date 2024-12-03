using Api.Models.DTO;
using Api.Models.Entities;
using Api.Repositories.Interfaces;
using Api.Services.Intefraces;
using AutoMapper;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUser(string login)
        {
            var user = _mapper.Map<UserDTO>(await _userRepository.GetUserAsync(login));
            return user;
        }
    }
}
