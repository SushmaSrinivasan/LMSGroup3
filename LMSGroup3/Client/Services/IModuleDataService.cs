using LMSGroup3.Shared.Domain.DTOs;
using System.Reflection;

namespace LMSGroup3.Client.Services
{
    public interface IModuleDataService
    {
        Task<Module?> GetAsync();
        Task<Module?> GetAsync(int id, bool includeActivities = false);
        Task<bool> AddAsync(Module module);
        Task<bool> UpdateAsync(ModuleDto Module);
        Task<bool> DeleteAsync(int id);
    }
}
