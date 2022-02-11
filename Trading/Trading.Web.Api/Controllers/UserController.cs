using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trading.Application.Services.Interfaces;
using Trading.Application.Services.Jwt;
using Trading.Domain.Entities;
using Trading.Web.Dto;
using Trading.Web.Dto.Validators;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trading.Web.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly IUserService _userService;

        private readonly JwtSettings _jwtSettings;

        public UserController(IUserService userService, JwtSettings jwtSettings, ILogger<UserController> logger)
        {
            _userService = userService;
            _jwtSettings = jwtSettings;
            _logger = logger;
        }

        /// <summary>
        /// User registration.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="Username"></param>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <param name="RPassword"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /User/Register
        ///     {
        ///        "Username": "Admin",
        ///        "Email": "admin@gmail.com",
        ///        "Password": "admin",
        ///        "RPassword": "admin"
        ///     }
        ///
        /// </remarks>
        /// <returns>The user inserted.</returns>

        [HttpPost("register")]
        public async Task<UserDto> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            UserRegisterDtoValidator validator = new();

            ValidationResult result = validator.Validate(userRegisterDto);

            if(result.IsValid)
            {
                UserEntity userEntity = await _userService.Register(UserRegisterDto.MapToUserEntity(userRegisterDto));

                return UserDto.MapToUserDto(userEntity);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    _logger.LogError(error.ToString());
                }

                throw new ValidationException(result.Errors);
            }
        }

        /// <summary>
        /// User login.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /User/Login
        ///     {
        ///        "Email": "admin@gmail.com",
        ///        "Password": "admin",
        ///     }
        ///
        /// </remarks>
        /// <returns>A token for the user, his email and the validation time of the token.</returns>

        [HttpPost("login")]
        public async Task<UserTokens> Login(UserLoginDto userLoginDto)
        {
            UserLoginDtoValidator validator = new();

            ValidationResult result = validator.Validate(userLoginDto);

            if(result.IsValid)
            {
                var user = await _userService.Login(userLoginDto.Email, userLoginDto.Password);

                UserTokens userToken = new UserTokens();

                userToken = JwtHelpers.GenTokenkey(new UserTokens()
                {
                    Username = user.Username,
                    Email = user.Email,
                    Guid = user.Guid
                }, _jwtSettings);

                return userToken;
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    _logger.LogError(error.ToString());
                }

                throw new ValidationException(result.Errors);
            }
        }
    }
}
