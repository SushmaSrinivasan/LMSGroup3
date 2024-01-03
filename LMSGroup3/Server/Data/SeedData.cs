﻿using LMSGroup3.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace LMSGroup3.Server.Data
{
    public class SeedData
    {
        private static ApplicationDbContext context = default!;
        private static RoleManager<IdentityRole> roleManager = default!;
        private static UserManager<ApplicationUser> userManager = default!;


        public static async Task Init(ApplicationDbContext _context, IServiceProvider services)
        {
            context = _context;

            if (context.Roles.Any()) return;

            roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            var roleNames = new[] { "Teacher", "Student" };
            var teacherEmail = "teacher@superuser.com";
            var studentEmail = "student@testaccount.com";

            await AddRolesAsync(roleNames);

            var teacher = await AddAccountAsync(teacherEmail, "Teacher", "SuperUser", "P@55w.rd");
            var student = await AddAccountAsync(studentEmail, "Student", "TestAccount", "P@55w.rd");

            await AddUserToRoleAsync(teacher, "Teacher");
            await AddUserToRoleAsync(student, "Student");
        }

        private static async Task AddRolesAsync(string[] roleNames)
        {
            foreach (var roleName in roleNames)
            {
                if (await roleManager.RoleExistsAsync(roleName)) continue;
                var role = new IdentityRole { Name = roleName };
                var result = await roleManager.CreateAsync(role);

                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
            }
        }

        private static async Task<ApplicationUser> AddAccountAsync(string accountEmail, string fName, string lName, string pWord)
        {
            var found = await userManager.FindByNameAsync(accountEmail);

            if (found != null) return null!;

            var user = new ApplicationUser
            {
                UserName = accountEmail,
                Email = accountEmail,
                FirstName = fName,
                LastName = lName,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, pWord);

            if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));

            return user;
        }

        private static async Task AddUserToRoleAsync(ApplicationUser user, string roleName)
        {
            if (!await userManager.IsInRoleAsync(user, roleName))
            {
                var result = await userManager.AddToRoleAsync(user, roleName);

                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
            }
        }
    }
}
