using System.Collections.Generic;
using System.Threading.Tasks;
using Trading.Domain.Entities;

namespace Trading.Application.Services.Interfaces
{
    public interface IStockService
    {
        Task SeedStocks(string url, string apikey);

        Task<StockEntity> GetStock(string symbol);

        Task<IEnumerable<StockEntity>> GetPaginated(int limit, int offset);
    }
}
