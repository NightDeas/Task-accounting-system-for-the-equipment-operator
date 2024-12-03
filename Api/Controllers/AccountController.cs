using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Api.Models.Entities;
using Api.Models.Requests;
using Api.Models.Responses;
using Api.Services;
using Api.Services.Intefraces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userService = userService;
        }
        [ProducesResponseType(typeof(RegisterDTOResponse), 200)]
        [ProducesResponseType(400)]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTORequest register)
        {
            var user = _mapper.Map<User>(register);
            var anyUser = await _userManager.FindByNameAsync(register.Login);
            if (anyUser != null)
            {
                return BadRequest("Пользователь с таким логином уже существует");
            }
            user.UserName = register.Login;
            var createResult = await _userManager.CreateAsync(user, register.Password);
            if (createResult.Succeeded)
            {
                var token = Services.JwtTokenService.Generate(user);
                var result = new RegisterDTOResponse()
                {
                    AccessToken = token,
                };
                return Ok(token);
            }
            return BadRequest();
        }
        [ProducesResponseType(typeof(RegisterDTOResponse), 200)]
        [ProducesResponseType(400)]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string login, string password)
        {
            User user = new()
            {
                UserName = login,
            };
            var signResult = await _signInManager.PasswordSignInAsync(login, password, false, false);
            if (signResult.Succeeded)
            {
                var token = JwtTokenService.Generate(user);
                return Ok(token);
            }
            return BadRequest("Неверный логин или пароль");
        }

        [HttpGet("User/Current")]
        public async Task<IActionResult> GetUser()
        {
            var userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            return Ok(new { Name = User.Identity.Name});
        }
    }
}
