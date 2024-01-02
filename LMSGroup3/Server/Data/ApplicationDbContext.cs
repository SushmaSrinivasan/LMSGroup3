using Duende.IdentityServer.EntityFramework.Options;
using LMSGroup3.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LMSGroup3.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Activity> Activities { get; set; } = null!;
        public DbSet<ActivityType> ActivityTypes { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Module> Modules { get; set; } = null!;


    }
}
