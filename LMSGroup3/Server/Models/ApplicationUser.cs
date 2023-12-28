﻿using Microsoft.AspNetCore.Identity;

namespace LMSGroup3.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => FirstName + " " + LastName;
        public Course CourseId { get; set; }
    }
}
