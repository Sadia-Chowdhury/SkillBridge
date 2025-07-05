using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SkillBridge.Models;
using System.Threading.Tasks;

namespace SkillBridge.Controllers
{
    [Authorize(Roles = "Developer")]
    public class DeveloperController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DeveloperController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Dashboard()
        {
            var user = await _userManager.GetUserAsync(User);

            var model = new DeveloperDashboardViewModel
            {
                FullName = user.FullName,
                Email = user.Email,
                Role = "Developer"
            };

            return View(model);
        }
    }
}
