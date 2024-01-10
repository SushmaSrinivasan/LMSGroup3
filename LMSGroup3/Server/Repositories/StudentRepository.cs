using global::LMSGroup3.Server.Models;
using LMSGroup3.Server.Data;
using LMSGroup3.Server.Models;
using LMSGroup3.Server.Repositories;
using LMSGroup3.Shared.Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using AutoMapper;
namespace LMSGroup3.Server.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Course> GetCourseForStudent(string studentId)
        {
            var course = _context.StudentCourses
                .Where(sc => sc.StudentId == studentId)
                .Select(sc => sc.Course)
                .FirstOrDefault();

            return course;
        }
        public async Task <IEnumerable<StudentCoursesDto>> GetStudentsInSameCourse(string studentId)
        {
            // Get the CourseId of the given student
            var courseId = _context.StudentCourses
                .Where(sc => sc.StudentId == studentId)
                .Select(sc => sc.CourseId)
                .FirstOrDefault();

            if (courseId == 0)
            {
                // CourseId not found for the given student
                return Enumerable.Empty<StudentCoursesDto>();
            }

            // Get the StudentIds of students in the same course
            var studentIdsInSameCourse = _context.StudentCourses
                .Where(sc => sc.CourseId == courseId && sc.StudentId != studentId)
                .Select(sc => sc.StudentId)
                .ToList();

            // Get the details of students in the same course
            var studentsInSameCourse = _context.Users
                .Where(u => studentIdsInSameCourse.Contains(u.Id) && u.Role == "Student")
                .Select(u => new StudentCoursesDto
                {
                    //Id = u.Id,
                    StudentId = u.Id,
                    CourseId = courseId
                })
                .ToList();

            return studentsInSameCourse;
        }
    }

}
