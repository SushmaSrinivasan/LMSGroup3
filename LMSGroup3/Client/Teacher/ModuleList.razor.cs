using LMSGroup3.Shared.Domain.DTOs;
using System.Net.Http.Json;

namespace LMSGroup3.Client.Teacher
{
    public partial class ModuleList
    {
        private List<ModuleDto> modules;

        protected override async Task OnInitializedAsync()
        {
            modules = await HttpClient.GetFromJsonAsync<List<ModuleDto>>("api/module/GetModules");
        }
    }
}
