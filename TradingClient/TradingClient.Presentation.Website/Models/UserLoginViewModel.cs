using System.ComponentModel.DataAnnotations;
using TradingClient.Common.Dto;

namespace TradingClient.Presentation.Website.Models
{
    public class UserLoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public static UserLoginDto MapToUserLoginDto(UserLoginViewModel userLoginViewModel)
        {
            return new UserLoginDto
            {
                Email = userLoginViewModel.Email,
                Password = userLoginViewModel.Password
            };
        }

        public static UserLoginViewModel MapToUserLoginViewModel(UserLoginDto userLoginDto)
        {
            return new UserLoginViewModel
            {
                Email = userLoginDto.Email,
                Password = userLoginDto.Password
            };
        }
    }
}
