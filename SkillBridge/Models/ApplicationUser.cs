using Microsoft.AspNetCore.Identity;
using System;

namespace SkillBridge.Models
{
    // ApplicationUser inherits from IdentityUser
    public class ApplicationUser : IdentityUser
    {
        // Extra fields you want to store for the user

        // To store whether the user is a Client or a Developer
        public string Role { get; set; } = "Developer";

        // To store the full name of the user
        public string FullName { get; set; }

        // To record when the user registered
        public DateTime JoinedDate { get; set; } = DateTime.Now;
    }
}
