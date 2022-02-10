using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingClient.Common.Dto;

namespace TradingClient.Business.Logic.Interfaces
{
    public interface IStockBl
    {
        Task<IEnumerable<StockDto>> GetPaginated(int limit, int offset);

        //Task<StockDto> GetStock(string symbol);
    }
}
