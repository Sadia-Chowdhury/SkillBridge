using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SkillBridge.Controllers
{
    [Authorize(Roles = "Developer")] // Only Developer role can access
    public class DeveloperController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
