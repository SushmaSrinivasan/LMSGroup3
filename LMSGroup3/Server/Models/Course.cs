namespace LMSGroup3.Server.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string CourseDescription { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Navigation Property
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();

        // FK
        public Module ModuleId { get; set; } = default!;
    }
}
