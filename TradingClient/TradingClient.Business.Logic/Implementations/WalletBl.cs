using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TradingClient.Business.Logic.Interfaces;
using TradingClient.Common.Dto;

namespace TradingClient.Business.Logic.Implementations
{
    public class WalletBl : IWalletBl
    {
        private readonly HttpClient _httpClient;

        private readonly IConfiguration _configuration;

        public WalletBl(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            _configuration = configuration;
        }

        public async Task<IEnumerable<WalletDto>> GetWallet(string username, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = _httpClient.GetAsync(_configuration.GetConnectionString("TradingApiURL") + $"Wallet/{username}").Result;

            var walletsDto = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<WalletDto>>(walletsDto);
        }

        public async Task<WalletDto> Post(WalletDto walletDto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //Create Http content
            var myContent = JsonConvert.SerializeObject(walletDto);

            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);

            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //Make call
            var response = _httpClient.PostAsync(_configuration.GetConnectionString("TradingApiURL") + $"Wallet", byteContent).Result;

            var dbWalletDto = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<WalletDto>(dbWalletDto);
        }
    }
}
