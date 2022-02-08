using System.Collections.Generic;
using System.Threading.Tasks;
using Trading.Infrastructure.Data.Model;

namespace Trading.Infrastructure.Repository.Interfaces
{
    public interface IStockRepository
    {
        Task SeedStocksAsync(List<Stock> stocks);

        Task<Stock> GetStock(string symbol);

        Task<IEnumerable<Stock>> GetPaginated(int limit, int offset);

        Task ClearStocks();
    }
}
