﻿using Microsoft.AspNetCore.Mvc;
using LMSGroup3.Server.Repositories;
using LMSGroup3.Shared.Domain.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace LMSGroup3.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Course")]
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
        [Route("GetCoursesWithModules")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCoursesWithModules()
        {
            var courses = await _courseRepository.GetAllCoursesWithModules();
            var courseDtos = _mapper.Map<List<CourseDto>>(courses);

            return Ok(courseDtos);
        }
        [HttpGet]
        [Route("GetCourses")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            var courses = await _courseRepository.GetAllCourses();
            var courseDtos = _mapper.Map<List<CourseDto>>(courses);

            return Ok(courseDtos);
        }
        //[HttpGet]
        //[Route("GetModulesByCourse")]
        //public async Task<ActionResult<IEnumerable<ModuleDto>>> GetModulesByCourse(int courseId)
        //{
        //    var moduleDto = await _courseRepository.GetCourseByIdAsync(courseId);

        //    if (moduleDto == null)
        //    {
        //        return NotFound("Course not found");
        //    }

        //    return Ok(moduleDto);
        //}

        [HttpGet]
        [Route("GetCourse/{courseId}")]
        public async Task<CourseDto> GetCourse(int courseId)
        {
            var result = _courseRepository.GetCourse(courseId);

            if (result.Status == TaskStatus.RanToCompletion)
            {
                var test2 = result.Result;
                var test = _mapper.Map<CourseDto>(test2);
                return test;
            }
            return null;
        }


        [HttpGet]
        [Route("GetModulesByCourse/{courseId}")]
        public async Task<ActionResult<IEnumerable<ModuleDto>>> GetModulesByCourse(int courseId)
        {
            var modules = await _courseRepository.GetModulesByCourseAsync(courseId);

            if (modules == null)
            {
                return NotFound("Modules not found");
            }

            var moduleDtos = _mapper.Map<List<ModuleDto>>(modules);
            return Ok(moduleDtos);
        }
       

        [HttpGet]
        [Route("GetActivitiesByModule/{moduleId}")]
        public async Task<ActionResult<IEnumerable<ActivityDto>>> GetActivitiesByModule(int moduleId)
        {
            var activities = await _courseRepository.GetActivitiesByModuleAsync(moduleId);

            if (activities == null)
            {
                return NotFound("Activities not found");
            }

            var activityDtos = _mapper.Map<List<ActivityDto>>(activities);
            return Ok(activityDtos);
        }


    }

}


