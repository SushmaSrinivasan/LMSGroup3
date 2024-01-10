using Microsoft.AspNetCore.Mvc;
using LMSGroup3.Server.Repositories;
using LMSGroup3.Shared.Domain.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace LMSGroup3.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetCourseForStudent/{studentId}")]
        public async Task<ActionResult<CourseDto>> GetCourseForStudent(string studentId)
        {
            var studentCourse = _studentRepository.GetCourseForStudent(studentId);

            if (studentCourse == null)
            {
                return NotFound($"No course found for student with ID {studentId}");
            }

            var courseDto = _mapper.Map<CourseDto>(studentCourse.Result);

            return Ok(courseDto);
        }
        [HttpGet]
        [Route("GetStudentsInSameCourse/{studentId}")]
        public ActionResult<IEnumerable<StudentCoursesDto>> GetStudentsInSameCourse(string studentId)
        {
            var studentsInSameCourse = _studentRepository.GetStudentsInSameCourse(studentId);

            if (studentsInSameCourse == null )
            {
                return NotFound($"No students found in the same course as student with ID {studentId}");
            }

            var studentsDto = _mapper.Map<IEnumerable<StudentCoursesDto>>(studentsInSameCourse);

            return Ok(studentsDto);
        }
    }
}
