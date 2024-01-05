using Microsoft.AspNetCore.Authorization;
using LMSGroup3.Shared.Domain.DTOs;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;
using System.Text.Json;


namespace LMSGroup3.Client.Pages
{
    [Authorize(Roles = "Teacher")]
    public partial class ModuleAdd
    {

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;
        public Module? Module { get; set; }

        public string ErrorMessage = string.Empty;

        [Parameter]
        public int CourseId { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        private async Task HandleValidSubmit()
        {
            var json = JsonSerializer.Serialize(Module);
            var httpContent = new StringContent(json, new MediaTypeHeaderValue("application/json"));
            var response = await HttpClient.PostAsync("api/module/AddModule", httpContent);

        }
    }
}
