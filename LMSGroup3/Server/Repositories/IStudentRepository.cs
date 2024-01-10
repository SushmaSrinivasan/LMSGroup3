using LMSGroup3.Server.Models;
using LMSGroup3.Shared.Domain.DTOs;
using LMSGroup3.Shared.DTOs;

namespace LMSGroup3.Server.Repositories
{
    public interface IStudentRepository
    {
        Task<Course> GetCourseForStudent(string studentId);
        Task<IEnumerable<ApplicationUserDto>> GetStudentsInSameCourse(string studentId);

        //Course GetCourseForStudent(string studentId);
    }

}
