using LMSGroup3.Server.Data;
using LMSGroup3.Shared.Entities;
using LMSGroup3.Server.Repositories;
using LMSGroup3.Shared.Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using AutoMapper;
using LMSGroup3.Shared.DTOs;
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

        public async Task<IEnumerable<ApplicationUserDto>> GetStudentsInCourse(int courseId)
        {
            // Retrieve student entities associated with the given course
            var courseWithUsers = _context.StudentCourses
                .Where(sc => sc.CourseId == courseId)
                .Select(sc => sc.Student);

            // Now, materialize the query to a list of users
            var studentsInCourse = await _context.Users
                .Where(u => courseWithUsers.Contains(u))
                .Select(u => new ApplicationUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email
                })
                .ToListAsync();

            return studentsInCourse;
        }

        public async Task<IEnumerable<ApplicationUserDto>> GetStudentsInSameCourse(string studentId)
        {
            // Get the CourseId of the given student
            var courseId = _context.StudentCourses
                .Where(sc => sc.StudentId == studentId)
                .Select(sc => sc.CourseId)
                .FirstOrDefault();

            if (courseId == 0)
            {
                // CourseId not found for the given student
                return Enumerable.Empty<ApplicationUserDto>();
            }

            // Get the StudentIds of students in the same course
            var studentIdsInSameCourse = _context.StudentCourses
                .Where(sc => sc.CourseId == courseId && sc.StudentId != studentId)
                .Select(sc => sc.StudentId)
                .ToList();

            // Get the details of students in the same course
            var studentsInSameCourse = _context.Users
                .Where(u => studentIdsInSameCourse.Contains(u.Id))
                .Select(u => new ApplicationUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email
                })
                .ToList();

            return studentsInSameCourse;
        }
    }
}
