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
        private readonly IEmployeeService _employeeService;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUserService userService, IEmployeeService employeeService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userService = userService;
            _employeeService = employeeService;
        }
        [ProducesResponseType(typeof(RegisterResponse), 200)]
        [ProducesResponseType(400)]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest register)
        {
            var user = _mapper.Map<User>(register);
            var anyUser = await _userManager.FindByNameAsync(register.Login);
            if (anyUser != null)
            {
                return BadRequest("Пользователь с таким логином уже существует");
            }
            user.UserName = register.Login;
            var createResult = await _userManager.CreateAsync(user, register.Password);
            await _userManager.AddToRoleAsync(user, "OPERATOR");
            if (createResult.Succeeded)
            {
                EmployeeRequest employeeRequest = new()
                {
                    UserId = user.Id,
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    Patronymic = register.Patronymic,

                };
                await _employeeService.Add(employeeRequest);
                var token = Services.JwtTokenService.Generate(user);
                var result = new RegisterResponse()
                {
                    AccessToken = token,
                };
                return Ok(token);
            }
            return BadRequest();
        }
        [ProducesResponseType(typeof(RegisterResponse), 200)]
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
            var userDTO = await _userService.GetCurrentUser();
            if (userDTO == null)
                return Unauthorized();
            var roles = await _userManager.GetRolesAsync(_mapper.Map<User>(userDTO));
            return Ok(new
            {
                userDTO.Login,
                Roles = roles
            });
        }
    }
}
