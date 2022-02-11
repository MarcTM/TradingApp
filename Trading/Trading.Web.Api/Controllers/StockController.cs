using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trading.Application.Services.Interfaces;
using Trading.Web.Dto;

namespace Trading.Web.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        private readonly IConfiguration _configuration;

        public StockController(IStockService stockService, IConfiguration configuration)
        {
            _stockService = stockService;
            _configuration = configuration;
        }

        /// <summary>
        /// Get a list of stocks paginated.
        /// </summary>
        /// <param name="version"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Stock
        ///
        /// </remarks>
        /// <returns>A list of stocks.</returns>

        [HttpGet]
        public async Task<IEnumerable<StockDto>> GetPaginated([System.Web.Http.FromUri] int limit, [System.Web.Http.FromUri] int offset)
        {
            if (limit <= 0)
                limit = 10;


            List<StockDto> stocksDto = new();

            var stocksEntity = await _stockService.GetPaginated(limit, offset);

            foreach (var stock in stocksEntity)
            {
                stocksDto.Add(StockDto.MapToStockDto(stock));
            }

            return stocksDto;
        }

        /// <summary>
        /// Get a stock by its symbol.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="symbol"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Stock/{symbol}
        ///
        /// </remarks>
        /// <returns>A stock.</returns>
        
        [HttpGet("{symbol}")]
        public async Task<StockDto> GetStock(string symbol)
        {
            return StockDto.MapToStockDto(await _stockService.GetStock(symbol));
        }
    }
}
