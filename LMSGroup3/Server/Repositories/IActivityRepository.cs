﻿using LMSGroup3.Shared.Entities;

namespace LMSGroup3.Server.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> Get(int id);
        Task<IEnumerable<Activity>> GetAllActivities();
        Task<IEnumerable<Activity>> GetActivitiesByModuleId(int moduleID);

    }
}
