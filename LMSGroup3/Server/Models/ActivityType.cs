namespace LMSGroup3.Server.Models
{
    public class ActivityType
    {
        public int Id { get; set; }
        public string ActivityTypeName { get; set; } = string.Empty;

        // 
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();

    }
}