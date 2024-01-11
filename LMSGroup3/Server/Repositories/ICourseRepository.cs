using LMSGroup3.Shared.Entities;
using LMSGroup3.Shared.Domain.DTOs;

namespace LMSGroup3.Server.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> GetCourse(int id);
        Task<IEnumerable<Course>> GetAllCourses();
        Task<IEnumerable<CourseDto>> GetAllCoursesWithModules();
        Task<IEnumerable<ModuleDto>> GetCourseByIdAsync(int courseid);
        Task<IEnumerable<Module>> GetModulesByCourseAsync(int courseId);
        Task<IEnumerable<Activity>> GetActivitiesByModuleAsync(int moduleId);
        Task<Course> GetCourseForStudent(string studentId);

    }
}