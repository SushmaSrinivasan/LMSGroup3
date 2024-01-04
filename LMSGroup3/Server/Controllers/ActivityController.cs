using AutoMapper;
using LMSGroup3.Server.Repositories;
using LMSGroup3.Shared.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMSGroup3.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
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
        public async Task<ActionResult<IEnumerable<ActivityDto>>> GetActivities()
        {

            int moduleId = 1;
            var activities = await _activityRepository.GetActivitiesByModuleId(moduleId);

           // var activities = await _activityRepository.GetAllActivities();
            var activityDtos = _mapper.Map<List<ActivityDto>>(activities);

            return Ok(activityDtos);
        }
    }
}

