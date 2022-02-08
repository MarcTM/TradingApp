using Newtonsoft.Json;
using System;
using Trading.Infrastructure.Data.Model;

namespace Trading.Domain.Entities
{
    public class StockEntity
    {
        public int Id { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public string Exchange { get; set; }

        public string Type { get; set; }

        public string Active { get; set; }

        public static Stock MapToStock(StockEntity stockEntity)
        {
            return new Stock
            {
                Symbol = stockEntity.Symbol,
                Name = stockEntity.Name,
                Exchange = stockEntity.Exchange,
                Type = stockEntity.Type,
                Active = stockEntity.Active
            };
        }

        public static StockEntity MapToStockEntity(Stock stock)
        {
            return new StockEntity
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                Name = stock.Name,
                Exchange = stock.Exchange,
                Type = stock.Type,
                Active = stock.Active
            };
        }
    }
}
