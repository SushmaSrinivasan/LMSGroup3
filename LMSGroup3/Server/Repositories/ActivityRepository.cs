using LMSGroup3.Server.Data;
using LMSGroup3.Server.Models;
using LMSGroup3.Shared.Domain.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LMSGroup3.Server.Repositories
{
    public class ActivityRepository: IActivityRepository
    {
        private readonly ApplicationDbContext _context;
        public ActivityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Activity> Get(int id)
        {
            return _context.Activities.FirstOrDefault(c => c.Id == id);
        }

        public async Task<IEnumerable<Activity>> GetAllActivities()
        {
            return _context.Activities;
        }
        public async Task<IEnumerable<Activity>> GetActivitiesByModuleId(int moduleId)
        {
            return await _context.Activities
                .Where(a => a.ModuleId == moduleId)
                .ToListAsync();
        }

    }
}
