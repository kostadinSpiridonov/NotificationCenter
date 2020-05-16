using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using NotificationCenter.DataAccess.Repositories;
using NotificationCenter.Web.Models;
using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace NotificationCenter.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginRepository _loginRepository;

        public AccountController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            string hashed = HashPassword(model.Password);

            if (!await _loginRepository.Exist(model.Username, hashed))
            {
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Username),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Home");
        }
        public string HashPassword(string password)
        {
            ICryptoService cryptoService = new PBKDF2();
            var salt = "100000.i7BB2tLt5UeYA9qDTRySyFjIJGgEZTDAFfesZeEr2mJqxA==";
            string hashed = cryptoService.Compute(password, salt);
            return hashed;
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
