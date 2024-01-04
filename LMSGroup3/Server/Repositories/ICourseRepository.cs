﻿using LMSGroup3.Server.Models;
using LMSGroup3.Shared.Domain.DTOs;

namespace LMSGroup3.Server.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> Get(int id);
        Task<IEnumerable<Course>> GetAllCourses();
        Task<IEnumerable<CourseDto>> GetAllCoursesWithModules();
        Task<IEnumerable<ModuleDto>> GetCourseByIdAsync(int courseid);
    }
}