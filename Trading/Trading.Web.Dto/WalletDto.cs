using System;
using Trading.Domain.Entities;

namespace Trading.Web.Dto
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

        public static WalletDto MapToWalletDto(WalletEntity walletEntity)
        {
            return new WalletDto
            {
                Amount = walletEntity.Amount,
                Price = walletEntity.Price,
                TransactionDate = walletEntity.TransactionDate,
                StockId = walletEntity.StockId,
                Stock = StockDto.MapToStockDto(walletEntity.Stock)
            };
        }

        public static WalletEntity MapToWalletEntity(WalletDto walletDto)
        {
            return new WalletEntity
            {
                Amount = walletDto.Amount,
                Price = walletDto.Price,
                StockId = walletDto.StockId,
                User = UserDto.MapToUserEntity(walletDto.User)
            };
        }
    }
}
