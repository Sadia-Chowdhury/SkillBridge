using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillBridge.Data;
using SkillBridge.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SkillBridge.Controllers
{
    [Authorize(Roles = "Developer")]
    public class DeveloperController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public DeveloperController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Dashboard()
        {
            var user = await _userManager.GetUserAsync(User);

            var applications = await _context.JobApplications
                .Include(a => a.JobPost)
                .Where(a => a.DeveloperId == user.Id)
                .ToListAsync();

            var model = new DeveloperDashboardViewModel
            {
                FullName = user.FullName,
                Email = user.Email,
                Role = "Developer",
                Applications = applications
            };

            return View(model);
        }
    }
}
