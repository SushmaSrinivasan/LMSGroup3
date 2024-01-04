using AutoMapper;
using LMSGroup3.Server.Repositories;
using LMSGroup3.Shared.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LMSGroup3.Server.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityRepository _activityRepository;

        private readonly IMapper _mapper;
        public ActivityController(IActivityRepository activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetActivities")]
        public async Task<ActionResult<IEnumerable<ActivityDto>>> GetCourses()
        {
            var activities = await _activityRepository.GetAllActivities();
            var activityDtos = _mapper.Map<List<ActivityDto>>(activities);

            return Ok(activityDtos);
        }
    }
}

