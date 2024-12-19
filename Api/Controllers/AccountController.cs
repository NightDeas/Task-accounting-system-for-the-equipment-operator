using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Api.Models.Entities;
using Api.Models.Requests;
using Api.Models.Responses;
using Api.Services;
using Api.Services.Intefraces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

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
        private readonly IStringLocalizer<AccountController> _localizer;

        const string adminRoleString = "ADMINISTRATOR";
        const string userRoleString = "OPERATOR";
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUserService userService, IEmployeeService employeeService, IStringLocalizer<AccountController> localizer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userService = userService;
            _employeeService = employeeService;
            _localizer = localizer;
        }
        [AllowAnonymous]
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
            await _userManager.AddToRoleAsync(user, userRoleString);
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
                var rolesUser = await _userManager.GetRolesAsync(user);
                var token = Services.JwtTokenService.Generate(user, rolesUser);
                var result = new RegisterResponse()
                {
                    AccessToken = token,
                };
                return Ok(token);
            }
            return BadRequest();
        }
        [AllowAnonymous]
        [ProducesResponseType(typeof(RegisterResponse), 200)]
        [ProducesResponseType(400)]
        [HttpPost("Register/isAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterRequest register)
        {
            var user = _mapper.Map<User>(register);
            var anyUser = await _userManager.FindByNameAsync(register.Login);
            if (anyUser != null)
            {
                return BadRequest("Пользователь с таким логином уже существует");
            }
            user.UserName = register.Login;
            var createResult = await _userManager.CreateAsync(user, register.Password);
            await _userManager.AddToRoleAsync(user, adminRoleString);
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
                var rolesUser = await _userManager.GetRolesAsync(user);
                var token = Services.JwtTokenService.Generate(user, rolesUser);
                var result = new RegisterResponse()
                {
                    AccessToken = token,
                };
                return Ok(token);
            }
            return BadRequest();
        }
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginResponse), 200)]
        [ProducesResponseType(400)]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Models.Requests.AuthRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.Login);
            if (user == null)
            {
                return BadRequest("Неверный логин или пароль");
            }

            var signResult = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, lockoutOnFailure: false);
            if (!signResult.Succeeded)
            {
                return BadRequest("Неверный логин или пароль");
            }

            var rolesUser = await _userManager.GetRolesAsync(user);

            // Генерируем JWT-токен
            var token = JwtTokenService.Generate(user, rolesUser);

            var response = new LoginResponse
            {
                AccessToken = token,
            };

            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("User/Current")]
        public async Task<IActionResult> GetUser()
        {
            var userDTO = await _userManager.GetUserAsync(User);
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
