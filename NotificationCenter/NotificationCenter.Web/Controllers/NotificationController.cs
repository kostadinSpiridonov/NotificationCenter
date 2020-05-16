using Microsoft.AspNetCore.Mvc;
using NotificationCenter.DataAccess;
using NotificationCenter.DataAccess.Repositories;
using NotificationCenter.Web.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NotificationCenter.Web.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            int clientId = int.Parse(User.Claims.Where(c => c.Type == ClaimTypes.Role)
                   .Select(c => c.Value).SingleOrDefault());
            var notifications = await _unitOfWork.NotificationRepository.GetByClientId(clientId);
            var mapped = notifications.Select(x => new NotificationModel
            {
                Name = x.Content
            });

            return View(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> SimulateUpdate()
        {
            var notifications = await _unitOfWork.RequestRepository.GetAll();
            var first = notifications.First();
            first.Status = "change";
            await _unitOfWork.RequestRepository.Update(first);
            await _unitOfWork.Commit();
            return RedirectToAction("Index", "Home");
        }
    }
}