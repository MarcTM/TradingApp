using System;
using System.Collections.Generic;
using Trading.Domain.Entities;

namespace Trading.Web.Dto
{
    public class UserDto
    {
        public Guid Guid { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public static UserDto MapToUserDto(UserEntity userEntity)
        {
            return new UserDto()
            {
                Guid = userEntity.Guid,
                Username = userEntity.Username,
                Email = userEntity.Email
            };
        }

        public static UserEntity MapToUserEntity(UserDto userDto)
        {
            return new UserEntity()
            {
                Guid = userDto.Guid,
                Username = userDto.Username,
                Email = userDto.Email
            };
        }
    }
}
