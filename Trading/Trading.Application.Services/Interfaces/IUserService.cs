using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.Domain.Entities;

namespace Trading.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity> Register(UserEntity userEntity);

        Task<UserEntity> Login(string email, string password);
    }
}
