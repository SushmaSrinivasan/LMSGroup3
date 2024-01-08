using Microsoft.AspNetCore.Authorization;
using LMSGroup3.Shared.Domain.DTOs;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Net.Http.Json;


namespace LMSGroup3.Client.Pages
{
    //[Authorize(Roles = "Teacher")]
    public partial class ModuleAdd : ComponentBase
    {

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;
        public ModuleDto Module { get; set; }

        public CourseDto course { get; set; }

        public string ErrorMessage = string.Empty;

        [Parameter]
        public int CourseId { get; set; }

        public string responseData = string.Empty;

      

        protected override async Task OnInitializedAsync()
        {
            var test = await HttpClient.GetFromJsonAsync<CourseDto>($"api/Course/GetCourse/{CourseId}");
            base.OnInitialized();
        }

        public async Task HandleValidSubmit()
        {
            try
            {
                Module.CourseId = CourseId;
                var json = JsonSerializer.Serialize(Module);
                var httpContent = new StringContent(json, new MediaTypeHeaderValue("application/json"));
                var response = await HttpClient.PostAsync("api/Module/AddModule", httpContent);
                if(response.IsSuccessStatusCode)
                {
                    responseData = await response.Content.ReadAsStringAsync();
                    NavigationManager.NavigateTo($"/courses");
                }
                else
                {
                    ErrorMessage = "Could not add Module " + response.StatusCode;
                }

            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }
          
        }
    }
}
