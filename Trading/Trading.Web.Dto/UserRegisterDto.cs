using System.ComponentModel.DataAnnotations;
using Trading.Domain.Entities;

namespace Trading.Web.Dto
{
    public class UserRegisterDto
    {
        public UserRegisterDto()
        {
        }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string RPassword { get; set; }

        public static UserEntity MapToUserEntity(UserRegisterDto userRegisterDto)
        {
            return new UserEntity()
            {
                Username = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                Password = userRegisterDto.Password,
                RPassword = userRegisterDto.RPassword
            };
        }
    }
}
