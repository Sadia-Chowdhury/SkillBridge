using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillBridge.Models
{
    public class JobPost
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [Display(Name = "Job Description")]
        public string Description { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string SkillsRequired { get; set; }

        public DateTime PostedDate { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Deadline")]
        public DateTime Deadline { get; set; }

        // 🔗 Foreign Key to ApplicationUser (Client)
        public string? ClientId { get; set; }

        [ForeignKey("ClientId")]
        public ApplicationUser? Client { get; set; }
    }
}
