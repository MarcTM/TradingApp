using System.Collections.Generic;
using System.Threading.Tasks;
using Trading.Domain.Entities;

namespace Trading.Application.Services.Interfaces
{
    public interface IWalletService
    {
        Task<IEnumerable<WalletEntity>> GetWallet(string username);

        Task<WalletEntity> Post(WalletEntity walletEntity);
    }
}
