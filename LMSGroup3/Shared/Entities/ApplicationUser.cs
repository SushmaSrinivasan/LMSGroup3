﻿using Microsoft.AspNetCore.Identity;


namespace LMSGroup3.Shared.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => FirstName + " " + LastName;

        //public string Role;

        // Navigation Property
        public Course Course { get; set; } = default!;

        // FK
        public int? CourseId { get; set; }
    }
}
