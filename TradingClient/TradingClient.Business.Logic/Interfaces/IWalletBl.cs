using System.Collections.Generic;
using System.Threading.Tasks;
using TradingClient.Common.Dto;

namespace TradingClient.Business.Logic.Interfaces
{
    public interface IWalletBl
    {
        Task<WalletDto> Post(WalletDto walletDto, string token);

        Task<IEnumerable<WalletDto>> GetWallet(string username, string token);
    }
}
