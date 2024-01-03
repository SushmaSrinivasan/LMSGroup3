using LMSGroup3.Server.Models;

namespace LMSGroup3.Server.Repositories
{
    public interface IModuleRepository
    {
        Task<Course> Get(int id);
        Task<IEnumerable<Module>> GetAllModules();
    }
}
