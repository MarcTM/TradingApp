using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Trading.Application.Services.Interfaces;
using Trading.Domain.Entities;
using Trading.Infrastructure.Repository.Interfaces;

namespace Trading.Application.Services.Implementations
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<IEnumerable<WalletEntity>> GetWallet(string username)
        {
            List<WalletEntity> walletsEntity = new();

            var wallets = await _walletRepository.GetWallet(username);

            foreach (var wallet in wallets)
            {
                walletsEntity.Add(WalletEntity.MapToWalletEntity(wallet));
            }

            return walletsEntity;
        }

        public async Task<WalletEntity> Post(WalletEntity walletEntity)
        {
            var wallet = await _walletRepository.Post(WalletEntity.MapToWallet(walletEntity));

            return WalletEntity.MapToWalletEntity(wallet);
        }
    }
}
