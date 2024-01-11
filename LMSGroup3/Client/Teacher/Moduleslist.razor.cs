using LMSGroup3.Shared.Domain.DTOs;
using System.Net.Http.Json;

namespace LMSGroup3.Client.Teacher
{
    public partial class Moduleslist
    {
        private List<ModuleDto> modules = new List<ModuleDto>();
        private int courseid = 3;
        protected override async Task OnInitializedAsync()
        {
            modules = await HttpClient.GetFromJsonAsync<List<ModuleDto>>($"api/Course/GetModulesByCourse?courseid={courseid}");
        }

    }
}