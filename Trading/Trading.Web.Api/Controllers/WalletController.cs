using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trading.Application.Services.Interfaces;
using Trading.Web.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trading.Web.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        private readonly IConfiguration _configuration;

        public WalletController(IWalletService walletService, IConfiguration configuration)
        {
            _walletService = walletService;
            _configuration = configuration;
        }

        /// <summary>
        /// Get user's wallets.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="username"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Wallet/{username}
        ///
        /// </remarks>
        /// <returns>A wallets list from a user.</returns>

        [HttpGet("{username=username}")]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IEnumerable<WalletDto>> GetWallet(string username)
        {
            List<WalletDto> walletsDto = new();

            var walletsEntity = await _walletService.GetWallet(username);

            foreach (var wallet in walletsEntity)
            {
                walletsDto.Add(WalletDto.MapToWalletDto(wallet));
            }

            return walletsDto;
        }

        /// <summary>
        /// A user can buy a stock.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="Amount"></param>
        /// <param name="Price"></param>
        /// <param name="StockId"></param>
        /// <param name="User"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Wallet
        ///     {
        ///        "Amount": "10",
        ///        "Price": "10",
        ///        "StockId": 1,
        ///        "User" {
        ///             "Username": "Admin"
        ///        }
        ///     }
        ///
        /// </remarks>
        /// <returns>The stock inserted in the wallet.</returns>

        [HttpPost()]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<WalletDto> Post(WalletDto walletDto)
        {
            var walletEntity = await _walletService.Post(WalletDto.MapToWalletEntity(walletDto));

            return WalletDto.MapToWalletDto(walletEntity);
        }
    }
}
