using System;
using System.Collections.Generic;
using Trading.Infrastructure.Data.Model;

namespace Trading.Domain.Entities
{
    public class UserEntity
    {
        public Guid Guid { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string RPassword { get; set; }

        //public ICollection<MyStockEntity> MyStocks { get; set; }

        public static UserEntity MapToUserEntity(User user)
        {
            return new UserEntity()
            {
                Guid = user.Guid,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password
            };
        }

        public static User MapToUser(UserEntity userEntity)
        {
            return new User()
            {
                Guid = userEntity.Guid,
                Username = userEntity.Username,
                Email = userEntity.Email,
                Password = userEntity.Password
            };
        }
    }
}
