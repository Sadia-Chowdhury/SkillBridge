using System;
using System.ComponentModel.DataAnnotations;

namespace SkillBridge.Models
{
    public class JobPost
    {
        public int Id { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Location { get; set; }

        public string? Description { get; set; }

        [Required]
        public string SkillsRequired { get; set; }

        public DateTime PostedDate { get; set; } = DateTime.Now;
    }
}
