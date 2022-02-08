using System;
using System.Threading.Tasks;
using Trading.Application.Services.Interfaces;
using Trading.Domain.Entities;
using Trading.Infrastructure.Data.Model;
using Trading.Infrastructure.Repository.Interfaces;

namespace Trading.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntity> Register(UserEntity userEntity)
        {
            if (userEntity.Password != userEntity.RPassword)
                throw new InvalidOperationException();

            userEntity.Guid = Guid.NewGuid();

            User user = await _userRepository.Register(UserEntity.MapToUser(userEntity));

            return UserEntity.MapToUserEntity(user);
        }

        public async Task<UserEntity> Login(string email, string password)
        {
            User user = await _userRepository.Login(email, password);

            if (user == null)
                throw new ArgumentNullException();

            return UserEntity.MapToUserEntity(user);
        }
    }
}
