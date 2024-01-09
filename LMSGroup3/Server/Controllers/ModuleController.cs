using Microsoft.AspNetCore.Mvc;
using LMSGroup3.Server.Repositories;
using LMSGroup3.Shared.Domain.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using LMSGroup3.Server.Models;

namespace LMSGroup3.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleRepository _moduleRepository;

        private readonly IMapper _mapper;
        public ModuleController(IModuleRepository moduleRepository, IMapper mapper)
        {
            _moduleRepository = moduleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetModules")]
        public async Task<ActionResult<IEnumerable<ModuleDto>>> GetModules()
        {
            var modules = await _moduleRepository.GetModules();
            var moduleDtos = _mapper.Map<List<ModuleDto>>(modules);

            return Ok(moduleDtos);
        }


        [HttpGet]
        [Route("GetModules/{id}")]
        public async Task<ModuleDto> GetModule(int Id)
        {
            return _mapper.Map<ModuleDto>(_moduleRepository.GetModules());
        }

        [HttpPost]
        [Route("AddModule")]

        public async Task<ActionResult<Module>> AddModule(Module module)
        {
            //var module = _mapper.Map<Module>(module);
           await _moduleRepository.AddModule(module);
            return Ok();

        }
    }

}