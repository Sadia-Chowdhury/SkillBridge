using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkillBridge.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SkillBridge.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
       


    }
}
