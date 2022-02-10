using System.ComponentModel.DataAnnotations;
using TradingClient.Common.Dto;

namespace TradingClient.Presentation.Website.Models
{
    public class UserRegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string RPassword { get; set; }

        public static UserRegisterDto MapToUserRegisterDto(UserRegisterViewModel userRegisterViewModel)
        {
            return new UserRegisterDto
            {
                Username = userRegisterViewModel.Username,
                Email = userRegisterViewModel.Email,
                Password = userRegisterViewModel.Password,
                RPassword = userRegisterViewModel.RPassword
            };
        }

        public static UserRegisterViewModel MapToUserRegisterViewModel(UserRegisterDto userRegisterDto)
        {
            return new UserRegisterViewModel
            {
                Username = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                Password = userRegisterDto.Password,
                RPassword = userRegisterDto.RPassword
            };
        }
    }
}
