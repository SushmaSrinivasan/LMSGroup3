using Bogus;
using LMSGroup3.Server.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

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
        // course names example
        private static string[] CourseNames = { "C#", "Javascript", "Blazor" };

        private static async Task<Course> CreateCourse()
        {
            var users = new List<ApplicationUser>();

            //adding teachers
            int teacherCount = Faker.Random.Int(1, 3);
            for (int i = 0; i < teacherCount; i++)
            {
                users.Add(GenerateUser());
            }
            //adding students
            int studentCount = Faker.Random.Int(2, 10);
            for (int i = 0; i < studentCount; i++)
            {
                users.Add(GenerateUser());
            }
            //adding users to userManager
            int j = 0;
            foreach (var user in users)
            {
                j++;
                await userManager.CreateAsync(user, "P@55w.rd");
                await userManager.AddToRoleAsync(user, (j < teacherCount ? Roles[0].Name : Roles[1].Name)!);
            }

            var startDate = Faker.Date.Between(DateTime.Now, DateTime.Now.AddDays(100));
            var endDate = startDate.AddDays(Faker.Random.Int(30, 120));

            var modules = GenerateModules(startDate, endDate);

            return new Course
            {
                CourseName = CourseNames[Faker.Random.Int(0, CourseNames.Length - 1)],
                CourseDescription = Faker.Lorem.Sentence(),
                StartDate = startDate,
                EndDate = endDate,
                Modules = modules,
                ApplicationUsers = users,
            };
        }

            //creating a single student
            private static ApplicationUser GenerateUser()
            {
                var firstname = Faker.Name.FirstName();
                var lastname = Faker.Name.LastName();
                var email = Faker.Internet.Email(firstname, lastname);
                var user = new ApplicationUser
                {
                    UserName = $"{firstname} {lastname}",
                    Email = email,
                    EmailConfirmed = true,
                };
                return user;
            }
            //creating modules with start and end date
            private static List<Models.Module> GenerateModules(DateTime start, DateTime end)
            {
                var output = new List<Models.Module>();
                var moduleCount = Faker.Random.Int(1, 4);
                for (int i = 0; i < moduleCount; i++)
                {
                    // create a module with a start date after the previous module's end date
                    output.Add(GenerateModule(i == 0 ? start : output[i - 1].EndDate));
                }
                return output;
            }

            //Example module names
            private static readonly string[] ModuleNames = { "C#", "SQL", "Javascript","EF Core" };

        //Creating a single module
        private static Models.Module GenerateModule(DateTime startDate)
        {
            var endDate = Faker.Date.Soon(4);
            return new Models.Module
            {
                ModuleName = ModuleNames[Faker.Random.Int(0, ModuleNames.Length - 1)],
                ModuleDescription = Faker.Lorem.Sentence(),
                StartDate = startDate,
                EndDate = endDate,
                Activities = GenerateActivities(ActivityTypes, startDate, endDate, ActivityDescription)
            };
        }

        //Example activity names
        private static readonly List<ActivityType> ActivityTypes = new List<ActivityType>
        {
            new ActivityType { ActivityTypeName = "E-Learning" },
            new ActivityType { ActivityTypeName = "Lecture" },
            new ActivityType { ActivityTypeName = "Assignment" },
        };

        //Example activity descriptions
        private static readonly string[] ActivityDescription = { "Pluralsight learnings", "Class Reviews", "Exercise Files" };


        //Creating activities for a module
        private static List<Activity> GenerateActivities(List<ActivityType> types, DateTime start, DateTime end, string[] activityDescription)
        {
            var activities = new List<Activity>();

            var activityCount = Faker.Random.Int(types.Count, 3 * types.Count);

            //creating activities randomly in any order
            for (int i = 0; i < activityCount; i++)
            {
                var type = types[Faker.Random.Int(0, types.Count - 1)];
                var description = ActivityDescription[Faker.Random.Int(0, (activityDescription.Length - 1))];
                var startDate = activities.Count == 0 ? start : activities[i - 1].EndDate;
                var endDate = activityCount == i - 1 ? end : Faker.Date.Between(startDate, end.Subtract(TimeSpan.FromSeconds(1)));
                activities.Add(new Activity
                {
                    ActivityDescription = description,
                    ActivityType = type,
                    StartDate = startDate,
                    EndDate = endDate,

                });
            }
            return activities;
        }
}
}
