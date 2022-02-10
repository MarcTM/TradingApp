using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingClient.Business.Logic.Implementations;
using TradingClient.Business.Logic.Interfaces;
using TradingClient.Common.Dto;
using TradingClient.Presentation.Website.Models;

namespace TradingClient.Presentation.Website.Controllers
{
    public class WalletController : Controller
    {
        private readonly ILogger<WalletController> _logger;

        private readonly IWalletBl _walletBl;

        private List<WalletViewModel> wallets;

        public WalletController(ILogger<WalletController> logger, IWalletBl walletBl)
        {
            _logger = logger;
            _walletBl = walletBl;
        }

        public async Task GetUserWallet()
        {
            List<WalletViewModel> walletsViewModel = new();

            var walletsDto = await _walletBl.GetWallet(HttpContext.Session.GetString("CurrentUserUsername"), HttpContext.Session.GetString("CurrentUserToken"));

            if(walletsDto.Count() > 0)
            {
                foreach (var wallet in walletsDto)
                {
                    walletsViewModel.Add(WalletViewModel.MapToWalletViewModel(wallet));
                }
            }
            
            wallets = walletsViewModel;
        }

        public IActionResult Index()
        {
            GetUserWallet().Wait();

            return View(wallets);
        }

        public IActionResult Add(int id)
        {
            HttpContext.Session.SetInt32("ActualStock", id);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Amount,Price")] WalletViewModel walletViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    walletViewModel.User = new UserViewModel
                    {
                        Username = HttpContext.Session.GetString("CurrentUserUsername")
                    };

                    var stockId = (int)HttpContext.Session.GetInt32("ActualStock");

                    walletViewModel.StockId = (int) HttpContext.Session.GetInt32("ActualStock");

                    var walletDto = await _walletBl.Post(WalletViewModel.MapToWalletDto(walletViewModel), HttpContext.Session.GetString("CurrentUserToken"));

                    return RedirectToAction("Index", "Wallet", new { });
                }
                catch (Exception ex)
                {
                    return View();
                }
            }

            return View();
        }
    }
}
