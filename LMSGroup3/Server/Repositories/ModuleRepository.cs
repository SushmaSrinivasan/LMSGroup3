using LMSGroup3.Server.Data;
using LMSGroup3.Server.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using LMSGroup3.Shared.Domain.DTOs;

namespace LMSGroup3.Server.Repositories
{
    public class ModuleRepository : IModuleRepository

    {
        private readonly ApplicationDbContext _context;
        public ModuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Module> GetModule(int id)
        {
            return _context.Modules.FirstOrDefault(c=>c.Id==id);   
        }

        public async Task<IEnumerable<Module>> GetModules()
        {
            return _context.Modules;
        }

        public async Task<Module> AddModule(Module module)
        {
            var addedEntity = await _context.Modules.AddAsync(module);
            await _context.SaveChangesAsync();
            return addedEntity.Entity;

        }

        //public async Task<Module> RemoveModule(int id, Module? module)
        //{
        //    //Module? module = new Module();
        //     module = await _context.Modules.FirstOrDefaultAsync(m => m.Id == id);
        //   var removedEntity= await _context.Modules.ExecuteDeleteAsync(module);
        //    await _context.SaveChangesAsync();
        //    return removedEntity.Entity;
        //}

      
    }
}
