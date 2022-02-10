using System;
using TradingClient.Common.Dto;

namespace TradingClient.Presentation.Website.Models
{
    public class WalletViewModel
    {
        public int Amount { get; set; }

        public double Price { get; set; }

        public DateTime TransactionDate { get; set; }

        public int StockId { get; set; }

        public StockViewModel Stock { get; set; }

        public int UserId { get; set; }

        public UserViewModel User { get; set; }

        public static WalletDto MapToWalletDto(WalletViewModel walletViewModel)
        {
            return new WalletDto
            {
                Amount = walletViewModel.Amount,
                Price = walletViewModel.Price,
                TransactionDate = walletViewModel.TransactionDate,
                StockId = walletViewModel.StockId,
                User = UserViewModel.MapToUserDto(walletViewModel.User)
            };
        }

        public static WalletViewModel MapToWalletViewModel(WalletDto walletDto)
        {
            return new WalletViewModel
            {
                Amount = walletDto.Amount,
                Price = walletDto.Price,
                TransactionDate = walletDto.TransactionDate,
                StockId = walletDto.StockId,
                Stock = StockViewModel.MapToStockViewModel(walletDto.Stock)
            };
        }
    }
}
