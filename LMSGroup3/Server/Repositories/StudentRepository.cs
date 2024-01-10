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
    }

}
