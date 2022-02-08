using System;
using Trading.Domain.Entities;

namespace Trading.Web.Dto
{
    public class StockDto
    {
        public int Id { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public string Exchange { get; set; }

        public string Type { get; set; }

        public string Active { get; set; }

        public static StockEntity MapToStockEntity(StockDto stockDto)
        {
            return new StockEntity()
            {
                Id  = stockDto.Id,
                Symbol = stockDto.Symbol,
                Name = stockDto.Name,
                Exchange = stockDto.Exchange,
                Type = stockDto.Type,
                Active = stockDto.Active
            };
        }

        public static StockDto MapToStockDto(StockEntity stockEntity)
        {
            return new StockDto()
            {
                Id = stockEntity.Id,
                Symbol = stockEntity.Symbol,
                Name = stockEntity.Name,
                Exchange = stockEntity.Exchange,
                Type = stockEntity.Type,
                Active = stockEntity.Active
            };
        }
    }
}
