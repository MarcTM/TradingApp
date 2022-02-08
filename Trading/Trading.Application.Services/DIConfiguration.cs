using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Trading.Infrastructure.Persistent;
using Trading.Infrastructure.Repository.Implementations;
using Trading.Infrastructure.Repository.Interfaces;

namespace Trading.Application.Services
{
    public class DIConfiguration
    {
        public void ConfigureSrevices(IServiceCollection services)
        {
            ConfigureRepositories(services);
            
            ConfigureHttpClientServices(services);

            ConfigureDatabase(services);
        }

        public void ConfigureHttpClientServices(IServiceCollection services)
        {
            HttpClient client = new();

            services.AddSingleton(client);
        }

        public void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IStockRepository, StockRepository>();

            services.AddScoped<IWalletRepository, WalletRepository>();
        }

        public void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<TradingDbContext>();
        }
    }
}
