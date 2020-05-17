using Microsoft.AspNetCore.Http;
using NotificationCenter.Web.Models;
using System.Threading.Tasks;

namespace NotificationCenter.Web.Services
{
    public interface IAccountService
    {
        Task<bool> LogInAsync(HttpContext httpContext, LoginViewModel model);

        Task LogOutAsync(HttpContext httpContext);
    }
}
