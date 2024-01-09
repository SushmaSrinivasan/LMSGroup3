using Microsoft.AspNetCore.Authorization;
using LMSGroup3.Shared.Domain.DTOs;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Net.Http.Json;
using System.Text;

namespace LMSGroup3.Client.Pages
{
    public partial class ModuleDelete : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;
        public ModuleDto module { get; set; } = new ModuleDto();

        //public CourseDto course { get; set; }

        public string ErrorMessage = string.Empty;

        [Parameter]
        public int Id { get; set; }

        public string responseData = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            module = await HttpClient.GetFromJsonAsync<ModuleDto>($"api/Module/GetModule/{Id}");
            base.OnInitialized();
        }

        public async Task HandleValidSubmit()
        {
            if (Id == null)
            {
                ErrorMessage = "Module not found";
                return;
            }

            await base.OnInitializedAsync();
        }
    }

//        private async task removemodule()
//        {

//        }
}
