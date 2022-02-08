using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.Infrastructure.Data.Model;

namespace Trading.Infrastructure.Repository.Interfaces
{
    public interface IWalletRepository
    {
        Task<IEnumerable<Wallet>> GetWallet(string username);

        Task<Wallet> Post(Wallet wallet);
    }
}
