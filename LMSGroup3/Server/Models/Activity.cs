namespace LMSGroup3.Server.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string ActivityName { get; set; } = string.Empty;
        public string ActivityDescription { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Navigation Property
        public ICollection<ActivityType> ActivityTypes { get; set; } = new List<ActivityType>();

        // FK
        public Module ModuleId { get; set; } = default!;
    }
}