using LMSGroup3.Server.Data;
using LMSGroup3.Server.Models;

namespace LMSGroup3.Server.Repositories
{
    public class ModuleRepository : IModuleRepository

    {
        private readonly ApplicationDbContext _context;
        public ModuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Module> Get(int id)
        {
            return _context.Modules.FirstOrDefault(m => m.Id == id);
        }

        public async Task<IEnumerable<Module>> GetAllModules()
        {
            return _context.Modules;
        }
    }
}
