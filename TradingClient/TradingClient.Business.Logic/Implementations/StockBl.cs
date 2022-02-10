using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TradingClient.Business.Logic.Interfaces;
using TradingClient.Common.Dto;

namespace TradingClient.Business.Logic.Implementations
{
    public class StockBl : IStockBl
    {
        private readonly HttpClient _httpClient;

        private readonly IConfiguration _configuration;

        public StockBl(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            _configuration = configuration;
        }

        public async Task<IEnumerable<StockDto>> GetPaginated(int limit, int offset)
        {
            var response = _httpClient.GetAsync(_configuration.GetConnectionString("TradingApiURL") + $"Stock?limit={limit}&offset={offset}").Result;

            var stockDto = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<StockDto>>(stockDto);
        }
    }
}
