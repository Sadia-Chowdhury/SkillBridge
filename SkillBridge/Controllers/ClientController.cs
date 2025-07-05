using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SkillBridge.Models;
using System.Threading.Tasks;

namespace SkillBridge.Controllers
{
    [Authorize(Roles = "Client")]
    public class ClientController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ClientController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Dashboard()
        {
            var user = await _userManager.GetUserAsync(User);

            var model = new ClientDashboardViewModel
            {
                FullName = user.FullName,
                Email = user.Email,
                Role = "Client"
            };

            return View(model);
        }
    }
}
