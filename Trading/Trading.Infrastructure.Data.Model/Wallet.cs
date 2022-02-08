using System;

namespace Trading.Infrastructure.Data.Model
{
    public class Wallet
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public int StockId { get; set; }

        public Stock Stock { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
