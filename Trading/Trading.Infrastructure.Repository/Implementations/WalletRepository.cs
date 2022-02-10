using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Infrastructure.Data.Model;
using Trading.Infrastructure.Persistent;
using Trading.Infrastructure.Repository.Interfaces;

namespace Trading.Infrastructure.Repository.Implementations
{
    public class WalletRepository : IWalletRepository
    {
        private readonly TradingDbContext _context;

        public WalletRepository(TradingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Wallet>> GetWallet(string username)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Username == username);

            var wallets = await _context.Wallet.Include("Stock").Where(u => u.UserId == user.Id).ToListAsync();

            return wallets;
        }

        public async Task<Wallet> Post(Wallet wallet)
        {
            User user = await _context.User.FirstOrDefaultAsync(u => u.Username == wallet.User.Username);

            wallet.UserId = user.Id;

            wallet.User = null;

            var addWallet = await _context.Wallet.AddAsync(wallet);

            await _context.SaveChangesAsync();

            var es = addWallet.Entity;

            Wallet newWallet = await _context.Wallet.Include("Stock").FirstOrDefaultAsync(u => u.Id == addWallet.Entity.Id);

            return newWallet;
        }
    }
}
