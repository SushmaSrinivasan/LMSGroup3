namespace LMSGroup3.Server.Models
{
    public class StudentCourses
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }

        public ApplicationUser Student { get; set; }
        public Course Course { get; set; }
    }

}

