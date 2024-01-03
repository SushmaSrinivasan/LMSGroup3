using LMSGroup3.Server.Models;

namespace LMSGroup3.Server.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> Get(int id);
        Task <IEnumerable<Course>> GetAllCourses();
    }
}