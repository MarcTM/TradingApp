using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trading.Infrastructure.Data.Model;
using Trading.Infrastructure.Persistent;
using Trading.Infrastructure.Repository.Interfaces;

namespace Trading.Infrastructure.Repository.Implementations
{
    public class StockRepository : IStockRepository
    {
        private readonly TradingDbContext _context;

        public StockRepository(TradingDbContext context)
        {
            _context = context;
        }

        public async Task SeedStocksAsync(List<Stock> stocks)
        {
            string query = "INSERT INTO Stock (Symbol, Name, Exchange, Type, Active) VALUES";

            foreach (var stock in stocks)
            {
                query += " (\"" + stock.Symbol + "\", \"" + stock.Name + "\", \"" + stock.Exchange + "\", \"" + stock.Type + "\", \"" + stock.Active + "\"),";
            }

            query = query.Remove(query.Length - 1, 1);

            await _context.Database.ExecuteSqlRawAsync(query);
        }

        public async Task ClearStocks()
        {
            var stocks = await _context.Stock.ToListAsync();

            if (stocks.Count > 0)
            {
                await _context.Database.ExecuteSqlRawAsync("DELETE FROM Stock");
            }
        }

        public async Task<Stock> GetStock(string symbol)
        {
            return await _context.Stock.FirstOrDefaultAsync(s => s.Symbol == symbol);
        }

        public async Task<IEnumerable<Stock>> GetPaginated(int limit, int offset)
        {
            string query = $"SELECT * FROM Stock LIMIT {limit} OFFSET {offset}";

            return await _context.Stock.FromSqlRaw(query).ToListAsync();
        }
    }
}
