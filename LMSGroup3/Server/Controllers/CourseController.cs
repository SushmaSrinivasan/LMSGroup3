using Microsoft.AspNetCore.Mvc;
using LMSGroup3.Server.Repositories;
using LMSGroup3.Shared.Domain.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace LMSGroup3.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
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
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            var courses =  await _courseRepository.GetAllCourses();
            var courseDtos = _mapper.Map<List<CourseDto>>(courses);

            return Ok(courseDtos);
            }
        }

    }

