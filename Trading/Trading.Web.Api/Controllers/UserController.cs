using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trading.Application.Services.Interfaces;
using Trading.Application.Services.Jwt;
using Trading.Domain.Entities;
using Trading.Web.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trading.Web.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly JwtSettings _jwtSettings;

        public UserController(IUserService userService, JwtSettings jwtSettings)
        {
            _userService = userService;
            _jwtSettings = jwtSettings;
        }

        [HttpPost("register")]
        public async Task<UserDto> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            UserEntity userEntity = await _userService.Register(UserRegisterDto.MapToUserEntity(userRegisterDto));

            return UserDto.MapToUserDto(userEntity);
        }

        [HttpPost("login")]
        public async Task<UserTokens> Login(UserLoginDto userLoginDto)
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
    }
}
