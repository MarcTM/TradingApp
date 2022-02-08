using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Trading.Application.Services.Interfaces;
using Trading.Domain.Entities;
using Trading.Infrastructure.Data.Model;
using Trading.Infrastructure.Repository.Interfaces;

namespace Trading.Application.Services.Implementations
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        private readonly HttpClient _client;

        public StockService(IStockRepository stockRepository, HttpClient client)
        {
            _stockRepository = stockRepository;
            _client = client;
        }

        // Seed stocks to database
        public async Task SeedStocks(string url, string apikey)
        {
            await _stockRepository.ClearStocks();

            var stocksCsv = await GetStocks(url, apikey);

            var stocks = new List<Stock>();

            using (var reader = new StreamReader(stocksCsv))
            {
                await reader.ReadLineAsync();

                while (!reader.EndOfStream)
                {
                    var line = (await reader.ReadLineAsync()).Split(",");

                    stocks.Add(new Stock
                    {
                        Symbol = line[0],
                        Name = line[1],
                        Exchange = line[2],
                        Type = line[3],
                        Active = line[6]
                    });
                }
            }

            await _stockRepository.SeedStocksAsync(stocks);
        }

        //Get stocks from api
        public async Task<MemoryStream> GetStocks(string url, string apikey)
        {
            _client.BaseAddress = new Uri(url);

            var response = await _client.GetAsync($"query?function=LISTING_STATUS&apikey={apikey}");

            var stocks = (MemoryStream) await response.Content.ReadAsStreamAsync();

            return stocks;
        }

        public async Task<StockEntity> GetStock(string symbol)
        {
            return StockEntity.MapToStockEntity(await _stockRepository.GetStock(symbol));
        }

        public async Task<IEnumerable<StockEntity>> GetPaginated(int limit, int offset)
        {
            List<StockEntity> stocksEntity = new();

            var stocks = await _stockRepository.GetPaginated(limit, offset);

            foreach (var stock in stocks)
            {
                stocksEntity.Add(StockEntity.MapToStockEntity(stock));
            }

            return stocksEntity;
        }
    }
}
