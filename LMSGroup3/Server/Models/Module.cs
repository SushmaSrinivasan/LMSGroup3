namespace LMSGroup3.Server.Models
{
    public class Module
    {
        public int Id { get; set; }

        public string ModuleName { get; set; } = string.Empty;

        public string ModuleDescription { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Navigation Property
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();

        //FK
        public Course CourseId { get; set; } = default!;
    }
}
