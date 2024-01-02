using AutoMapper;
using global::LMSGroup3.Server.Data;
using global::LMSGroup3.Server.Models;
using LMSGroup3.Server.Data;
using LMSGroup3.Server.Models;
using LMSGroup3.Server.Repositories;
using Microsoft.Identity.Client;

namespace LMSGroup3.Server.Repositories
{


    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Course> Get(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.Id == id);
        }

        public async Task<IEnumerable<Course> >GetAllCourses()
        {
            return  _context.Courses;
        }
    }
}

