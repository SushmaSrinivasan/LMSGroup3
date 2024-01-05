using Microsoft.AspNetCore.Mvc;
using LMSGroup3.Server.Repositories;
using LMSGroup3.Shared.Domain.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace LMSGroup3.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        private readonly IMapper _mapper;
        public CourseController(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetCourses")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            var courses = await _courseRepository.GetAllCourses();
            var courseDtos = _mapper.Map<List<CourseDto>>(courses);

            return Ok(courseDtos);

        }

        [HttpGet]
        [Route("GetCourseAndModules")]
        public async Task<ActionResult<CourseDto>> GetCourseAndModules(int Id)
        {
            var course = await _courseRepository.Get(Id);
            var courseDto = _mapper.Map<CourseDto>(course);

            return Ok(courseDto);
        }
    }


}

