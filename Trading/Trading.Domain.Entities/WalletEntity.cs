using System;
using Trading.Infrastructure.Data.Model;

namespace Trading.Domain.Entities
{
    public class WalletEntity
    {
        public int Amount { get; set; }

        public double Price { get; set; }

        public DateTime TransactionDate { get; set; }

        public int StockId { get; set; }

        public StockEntity Stock { get; set; }

        public int UserId { get; set; }

        public UserEntity User { get; set; }

        public static WalletEntity MapToWalletEntity(Wallet wallet)
        {
            return new WalletEntity
            {
                Amount = wallet.Amount,
                Price = wallet.Price,
                TransactionDate = wallet.TransactionDate,
                StockId = wallet.StockId,
                Stock = StockEntity.MapToStockEntity(wallet.Stock)
            };
        }

        public static Wallet MapToWallet(WalletEntity walletEntity)
        {
            return new Wallet
            {
                Amount = walletEntity.Amount,
                Price = walletEntity.Price,
                StockId = walletEntity.StockId,
                User = UserEntity.MapToUser(walletEntity.User)
            };
        }
    }
}
