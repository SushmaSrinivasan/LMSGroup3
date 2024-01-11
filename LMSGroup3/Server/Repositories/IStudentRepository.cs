using LMSGroup3.Shared.Entities;
using LMSGroup3.Shared.Domain.DTOs;
using LMSGroup3.Shared.DTOs;

namespace LMSGroup3.Server.Repositories
{
    public interface IStudentRepository
    {
        Task<Course> GetCourseForStudent(string studentId);
        Task<IEnumerable<ApplicationUserDto>> GetStudentsInSameCourse(string studentId);
        Task<IEnumerable<ApplicationUserDto>> GetStudentsInCourse(int courseId);

        //Course GetCourseForStudent(string studentId);
    }
}
