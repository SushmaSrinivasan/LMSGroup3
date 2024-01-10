using LMSGroup3.Server.Models;

namespace LMSGroup3.Server.Repositories
{
    public interface IStudentRepository
    {
        Task<Course> GetCourseForStudent(string studentId);

        //Course GetCourseForStudent(string studentId);
    }

}
