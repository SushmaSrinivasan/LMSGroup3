using Duende.IdentityServer.EntityFramework.Options;
using LMSGroup3.Shared.Entities;
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

		public DbSet<Course> Courses { get; set; } = null!;
		public DbSet<Module> Modules { get; set; } = null!;

		public DbSet<Activity> Activities { get; set; } = null!;

		public DbSet<ActivityType> ActivityTypes { get; set; } = null!;

		public DbSet<StudentCourses> StudentCourses { get; set; }
		//    protected override void OnModelCreating(ModelBuilder modelBuilder)
		//    {
		//        base.OnModelCreating(modelBuilder);

		//        // Configuration for StudentCourses
		//        modelBuilder.Entity<StudentCourses>()
		//            .HasKey(sc => sc.Id);

		//        // Relationships
		//        modelBuilder.Entity<StudentCourses>()
		//            .HasOne(sc => sc.Student)
		//            .WithMany(s => s.StudentCourses)
		//            .HasForeignKey(sc => sc.StudentId)
		//            .OnDelete(DeleteBehavior.Cascade);  // Adjust the delete behavior as needed

		//        modelBuilder.Entity<StudentCourses>()
		//            .HasOne(sc => sc.Course)
		//            .WithMany(c => c.ApplicationUsers)
		//            .HasForeignKey(sc => sc.CourseId)
		//            .OnDelete(DeleteBehavior.Cascade);  // Adjust the delete behavior as needed
		//    }
		//}


	}
}