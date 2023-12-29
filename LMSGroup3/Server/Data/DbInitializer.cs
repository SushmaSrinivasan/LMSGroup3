using Bogus;
using LMSGroup3.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace LMSGroup3.Server.Data
{
    public class DbInitializer
    {
        private static readonly Faker Faker = new Faker();
        private static RoleManager<IdentityRole> roleManager = default!;
        private static UserManager<ApplicationUser> userManager = default!;

        //creating roles
        private static readonly List<IdentityRole> Roles = new()
        {
        new IdentityRole { Name = "Teacher" },
        new IdentityRole { Name = "Student" }
        };

        public static async Task InitAsync(ApplicationDbContext db, IServiceProvider services)
        {
            roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            // adding roles if it does not exist already
            foreach (var role in Roles)
            {
                if (!await roleManager.RoleExistsAsync(role.Name!))
                {
                    await roleManager.CreateAsync(role);
                }
            }

            userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            const int courseCount = 3;
            var courses = new List<Course>();
            for (int i = 0; i < courseCount; i++)
            {
                courses.Add(await CreateCourse());
            }
            await db.AddRangeAsync(courses);
            await db.SaveChangesAsync();

        }
}
