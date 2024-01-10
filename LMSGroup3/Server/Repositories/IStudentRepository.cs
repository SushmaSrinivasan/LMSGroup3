using LMSGroup3.Server.Models;
using LMSGroup3.Shared.Domain.DTOs;

namespace LMSGroup3.Server.Repositories
{
    public interface IStudentRepository
    {
        Task<Course> GetCourseForStudent(string studentId);
        Task<IEnumerable<StudentCoursesDto>> GetStudentsInSameCourse(string studentId);

        //Course GetCourseForStudent(string studentId);
    }

}
