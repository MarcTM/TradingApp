using System.Threading.Tasks;
using TradingClient.Common.Dto;

namespace TradingClient.Business.Logic.Interfaces
{
    public interface IUserBl
    {
        Task<UserTokensDto> Login(UserLoginDto userLoginDto);

        Task<UserDto> Register(UserRegisterDto userRegisterDto);
    }
}
