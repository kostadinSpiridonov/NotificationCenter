using Microsoft.AspNetCore.Mvc;
using NotificationCenter.Web.Models;
using NotificationCenter.Web.Services;
using System.Threading.Tasks;

namespace NotificationCenter.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (await _accountService.LogInAsync(HttpContext, model))
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid password or username.");
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _accountService.LogOutAsync(HttpContext);
            return RedirectToAction("Index", "Home");
        }
    }
}
