using System.Security.Claims;
using Api.Models.DTO;
using Api.Models.Entities;
using Api.Repositories.Interfaces;
using Api.Services.Intefraces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, IMapper mapper, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        //public async Task<UserDTO> GetUser(string login)
        //{
        //    var user = _mapper.Map<UserDTO>(await _userRepository.GetUserAsync(login));
        //    return user;
        //}

        public async Task<UserDTO> GetCurrentUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return null;
            var user = await _userManager.FindByIdAsync(userId);
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }
    }
}
