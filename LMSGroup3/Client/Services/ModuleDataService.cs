using LMSGroup3.Client.Helpers;
using LMSGroup3.Shared.Domain.DTOs;
using System.Reflection;

namespace LMSGroup3.Client.Services
{
    public class ModuleDataService : IModuleDataService
    {
        private readonly IGenericDataService dataService;

        public ModuleDataService(IGenericDataService genericDataService)
        {
            dataService = genericDataService;
        }

        public async Task<Module?> GetAsync() => await dataService.GetAsync<Module>(UriHelpers.GetModulesUri());

        public async Task<Module?> GetAsync(int id, bool includeActivities = false) => await dataService.GetAsync<Module>(UriHelpers.GetModuleUri(id, includeActivities));

        public async Task<bool> AddAsync(Module module) => await dataService.AddAsync(UriHelpers.GetModulesUri(), module);
        public async Task<bool> UpdateAsync(ModuleDto Module) => await dataService.UpdateAsync(UriHelpers.GetModuleUri(Module.Id), Module);

        public async Task<bool> DeleteAsync(int id) => await dataService.DeleteAsync(UriHelpers.GetModuleUri(id));

    }
}
