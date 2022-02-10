using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TradingClient.Business.Logic.Interfaces;
using TradingClient.Common.Dto;

namespace TradingClient.Business.Logic.Implementations
{
    public class UserBl : IUserBl
    {
        private readonly HttpClient _httpClient;

        private readonly IConfiguration _configuration;

        public UserBl(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            _configuration = configuration;
        }

        public async Task<UserTokensDto> Login(UserLoginDto userLoginDto)
        {
            //Create Http content
            var myContent = JsonConvert.SerializeObject(userLoginDto);

            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);

            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //Make call
            var response = _httpClient.PostAsync(_configuration.GetConnectionString("TradingApiURL") + "User/login", byteContent).Result;

            var userTokensDto = await response.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<UserTokensDto>(userTokensDto);
        }

        public async Task<UserDto> Register(UserRegisterDto userRegisterDto)
        {
            //Create Http content
            var myContent = JsonConvert.SerializeObject(userRegisterDto);

            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);

            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //Make call
            var response = _httpClient.PostAsync(_configuration.GetConnectionString("TradingApiURL") + "User/register", byteContent).Result;

            var userDto = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDto>(userDto);
        }
    }
}
