using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using NotificationCenter.DataAccess;
using NotificationCenter.DataAccess.Entities;
using NotificationCenter.Web.Models;
using NotificationCenter.Web.Services.Auth;
using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NotificationCenter.Web.Services
{
    internal class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> LogInAsync(HttpContext httpContext, LoginViewModel model)
        {
            string hashed = HashPassword(model.Password);

            Login login = await _unitOfWork.LoginRepository.GetAsync(model.Username, hashed);
            if (login == null)
            {
                return false;
            }

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
            };

            ClaimsIdentity identity = BuildIdentity(model.Username, login.ClientId);

            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                authProperties);

            return true;
        }

        public Task LogOutAsync(HttpContext httpContext)
        {
            return httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private ClaimsIdentity BuildIdentity(string username, int clientId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(NotificationClaimTypes.ClientId, clientId.ToString())

            };

            return new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private string HashPassword(string password)
        {
            var cryptoService = new PBKDF2();

            // TODO: store in some securure place
            var salt = "100000.i7BB2tLt5UeYA9qDTRySyFjIJGgEZTDAFfesZeEr2mJqxA==";

            return cryptoService.Compute(password, salt);
        }
    }
}
