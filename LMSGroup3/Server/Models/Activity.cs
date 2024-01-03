namespace LMSGroup3.Server.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string ActivityDescription { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Navigation Property
        public ActivityType ActivityType { get; set; }

        public Module Module { get; set; } = default!;

        // FK
        public int ModuleId { get; set; }

        public int ActivityTypeId { get; set; }
    }
}