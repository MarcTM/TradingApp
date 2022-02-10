using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingClient.Business.Logic.Interfaces;
using TradingClient.Common.Dto;
using TradingClient.Presentation.Website.Models;

namespace TradingClient.Presentation.Website.Controllers
{
    public class StockController : Controller
    {
        private readonly ILogger<StockController> _logger;

        private readonly IStockBl _stockBl;

        private List<StockViewModel> stocks;

        public StockController(ILogger<StockController> logger, IStockBl stockBl)
        {
            _logger = logger;
            _stockBl = stockBl;
        }

        public async Task GetStocksPaginated()
        {
            List<StockViewModel> stocksViewModel = new();

            var stocksDto = await _stockBl.GetPaginated(20,0);

            foreach (var stock in stocksDto)
            {
                stocksViewModel.Add(StockViewModel.MapToStockViewModel(stock));
            }

            stocks = stocksViewModel;
        }

        public IActionResult Index()
        {
            GetStocksPaginated().Wait();

            return View(stocks);
        }
    }
}
