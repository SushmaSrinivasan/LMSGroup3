using LMSGroup3.Server.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMSGroup3.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        [Route("GetAllCourses")]
        public IActionResult GetAllCourses()
        {
            return Ok(_courseRepository.GetAllCourses());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_courseRepository.Get(id));
        }
    }
}
