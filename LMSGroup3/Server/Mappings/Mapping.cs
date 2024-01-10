using AutoMapper;
using LMSGroup3.Server.Models;
using LMSGroup3.Shared.Domain.DTOs;
using LMSGroup3.Shared.DTOs;



namespace LMSGroup3.Server.Mappings

{
    public class Mapping : Profile
    {

        public Mapping()
        {

            CreateMap<Course, CourseDto>();
            CreateMap<Activity, ActivityDto>();
            CreateMap<Module, ModuleDto>();
            CreateMap<StudentCourses, StudentCoursesDto>();
            CreateMap<ApplicationUser, ApplicationUserDto>();




        }
    }

}
