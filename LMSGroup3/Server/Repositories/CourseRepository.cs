using AutoMapper;
using global::LMSGroup3.Server.Data;
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


    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CourseRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Course> Get(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.Id == id);
        }

        public async Task<IEnumerable<Course> >GetAllCourses()
        {
            return  _context.Courses;
        }
        public async Task<IEnumerable<CourseDto>> GetAllCoursesWithModules()
        {
            var coursesWithModules = await _context.Courses
                .Include(c => c.Modules)
                .ToListAsync();

            var courseDto = coursesWithModules
                .SelectMany(course => course.Modules.Select(module => new CourseDto
                {
                    Id = course.Id,
                    CourseName = course.CourseName,
                    CourseDescription = course.CourseDescription,
                    StartDate= course.StartDate,
                    EndDate= course.EndDate,
                    ModuleId = module.Id,
                    ModuleName = module.ModuleName
   
                }))
                .ToList();

            return courseDto;
        }
        public async Task<IEnumerable<ModuleDto>> GetCourseByIdAsync(int courseId)
        {
            var modules = await _context.Courses
                .Include(c => c.Modules)
                .FirstOrDefaultAsync(c => c.Id == courseId);
            var modulesDto = _mapper.Map<List<ModuleDto>>(modules.Modules);
            return modulesDto;
        }
        

        public async Task<IEnumerable<Module>> GetModulesByCourseAsync(int courseId)
        {
            return await _context.Modules
                .Where(m => m.CourseId == courseId)
                .ToListAsync();
        }
       

        public async Task<IEnumerable<Activity>> GetActivitiesByModuleAsync(int moduleId)
        {
            return await _context.Activities
                .Where(a => a.ModuleId == moduleId)
                .ToListAsync();
        }

        //public async Task<IEnumerable<CourseDto>> GetAllCoursesWithModules()
        //{
        //    var courses = await _context.Courses
        //        .Include(c => c.Modules)
        //        .ToListAsync();

        //    // Map the entities to DTOs
        //    var courseDtos = _mapper.Map<List<CourseDto>>(courses);
        //    return courseDtos;

        //    //return courses;
        //}
    }
}

