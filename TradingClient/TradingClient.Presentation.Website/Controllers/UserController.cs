using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TradingClient.Business.Logic.Interfaces;
using TradingClient.Common.Dto;
using TradingClient.Presentation.Website.Models;

namespace TradingClient.Presentation.Website.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private readonly IUserBl _userBl;

        public UserController(ILogger<UserController> logger, IUserBl userBl)
        {
            _logger = logger;
            _userBl = userBl;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserTokensDto userTokensDto = await _userBl.Login(UserLoginViewModel.MapToUserLoginDto(userLoginViewModel));

                    SaveUserSessions(userTokensDto);

                    return RedirectToAction("Index", "Stock", new { });
                    //return RedirectToAction("Index", "Stock", new { area = "" });
                }
                catch (Exception ex)
                {
                    return View();
                }
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Username,Email,Password,RPassword")] UserRegisterViewModel userRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserDto userDto = await _userBl.Register(UserRegisterViewModel.MapToUserRegisterDto(userRegisterViewModel));

                    return RedirectToAction(nameof(Login));
                }
                catch (Exception ex)
                {
                    return View();
                }
            }

            return View();
        }

        public IActionResult Logout()
        {
            RemoveUserSessions();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        private void SaveUserSessions(UserTokensDto userTokensDto)
        {
            HttpContext.Session.SetString("CurrentUserUsername", userTokensDto.Username);
            HttpContext.Session.SetString("CurrentUserToken", userTokensDto.Token);
        }

        private void RemoveUserSessions()
        {
            HttpContext.Session.Remove("CurrentUserUsername");
            HttpContext.Session.Remove("CurrentUserToken");
        }
    }
}
