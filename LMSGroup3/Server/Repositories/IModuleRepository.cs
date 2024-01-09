using LMSGroup3.Server.Models;

namespace LMSGroup3.Server.Repositories
{
    public interface IModuleRepository
    {
        Task<Module> GetModule(int id);
        Task<IEnumerable<Module>> GetModules();

        Task<Module> AddModule(Module module);

        //Task<Module> RemoveModule(int id, Module module);
    }
}
