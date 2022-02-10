using System;

namespace TradingClient.Common.Dto
{
    public class WalletDto
    {
        public int Amount { get; set; }

        public double Price { get; set; }

        public DateTime TransactionDate { get; set; }

        public int StockId { get; set; }

        public StockDto Stock { get; set; }

        public int UserId { get; set; }

        public UserDto User { get; set; }
    }
}
