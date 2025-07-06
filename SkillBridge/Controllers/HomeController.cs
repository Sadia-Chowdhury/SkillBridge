using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillBridge.Data;
using SkillBridge.Models;
using System.Diagnostics;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var jobs = await _context.JobPosts.ToListAsync();
        return View(jobs);
    }

    [HttpPost]
    [Authorize(Roles = "Developer")]
    public async Task<IActionResult> Apply(int id)  // id = JobPostId
    {
        var user = await _userManager.GetUserAsync(User);

        // Check if already applied
        var alreadyApplied = await _context.JobApplications
            .AnyAsync(a => a.JobPostId == id && a.DeveloperId == user.Id);

        if (!alreadyApplied)
        {
            var application = new JobApplication
            {
                JobPostId = id,
                DeveloperId = user.Id
            };

            _context.JobApplications.Add(application);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
