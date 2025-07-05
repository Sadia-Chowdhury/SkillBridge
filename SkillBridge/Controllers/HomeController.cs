using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  // add this
using SkillBridge.Data;               // add this
using SkillBridge.Models;             // add this
using System.Diagnostics;
using System.Threading.Tasks;         // add this

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var jobs = await _context.JobPosts.ToListAsync();
        return View(jobs);  // pass the list of jobs to view
    }

    public IActionResult AccessDenied() => View();
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
