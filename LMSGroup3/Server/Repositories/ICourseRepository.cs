using LMSGroup3.Server.Models;

namespace LMSGroup3.Server.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();
        Course Get(int courseId);
    }
}