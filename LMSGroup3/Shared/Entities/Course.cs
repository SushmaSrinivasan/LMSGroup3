namespace LMSGroup3.Shared.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string CourseDescription { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Navigation Property
        public ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();

        public ICollection<Module> Modules { get; set; } = new List<Module>();
    }
}
