using System;
using TradingClient.Common.Dto;

namespace TradingClient.Presentation.Website.Models
{
    public class UserViewModel
    {
        public Guid Guid { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public static UserDto MapToUserDto(UserViewModel userViewModel)
        {
            return new UserDto
            {
                Guid = userViewModel.Guid,
                Username = userViewModel.Username,
                Email = userViewModel.Email
            };
        }

        public static UserViewModel MapToUserViewModel(UserDto userDto)
        {
            return new UserViewModel
            {
                Guid = userDto.Guid,
                Username = userDto.Username,
                Email = userDto.Email
            };
        }
    }
}
