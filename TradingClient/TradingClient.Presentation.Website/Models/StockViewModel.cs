using TradingClient.Common.Dto;

namespace TradingClient.Presentation.Website.Models
{
    public class StockViewModel
    {
        public int Id { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public string Exchange { get; set; }

        public string Type { get; set; }

        public string Active { get; set; }

        public static StockDto MapToStockDto(StockViewModel stockViewModel)
        {
            return new StockDto
            {
                Id = stockViewModel.Id,
                Symbol = stockViewModel.Symbol,
                Name = stockViewModel.Name,
                Exchange = stockViewModel.Exchange,
                Type = stockViewModel.Type,
                Active = stockViewModel.Active
            };
        }

        public static StockViewModel MapToStockViewModel(StockDto stockDto)
        {
            return new StockViewModel
            {
                Id = stockDto.Id,
                Symbol = stockDto.Symbol,
                Name = stockDto.Name,
                Exchange = stockDto.Exchange,
                Type = stockDto.Type,
                Active = stockDto.Active
            };
        }
    }
}
