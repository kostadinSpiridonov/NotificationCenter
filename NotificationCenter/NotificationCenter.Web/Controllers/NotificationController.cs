using Microsoft.AspNetCore.Mvc;
using NotificationCenter.Web.Services;
using NotificationCenter.Web.Services.Auth;
using System.Threading.Tasks;

namespace NotificationCenter.Web.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            int clientId = User.GetClientId();
            var notifications = await _notificationService.GetAllAsync(clientId);

            return View(notifications);
        }

        [HttpPost]
        public async Task<IActionResult> SimulateRequestUpdate()
        {
            await _notificationService.SimulateRequestUpdateAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}