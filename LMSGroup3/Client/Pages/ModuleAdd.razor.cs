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
    //[Authorize(Roles = "Teacher")]
    public partial class ModuleAdd : ComponentBase
    {

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;
        public ModuleDto Module { get; set; } = new ModuleDto();

        public CourseDto Course { get; set; } = new CourseDto();

        public string ErrorMessage = string.Empty;

        [Parameter]
        public int CourseId { get; set; }

        public string responseData = string.Empty;

      

        protected override async Task OnInitializedAsync()
        {
            Course = await HttpClient.GetFromJsonAsync<CourseDto>($"api/Course/GetCourse/{CourseId}");
            base.OnInitialized();
        }

        public async Task HandleValidSubmit()
        {
            try
            {
                Module.CourseId = CourseId;
                //var json = JsonSerializer.Serialize(Module);
                using var client = new HttpClient();

                //var httpContent = new StringContent(json, new MediaTypeHeaderValue("application/json"));
                //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsJsonAsync($"api/Module/AddModule", Module);
                
                                 
                if (response.IsSuccessStatusCode)
                {
                    //responseData = await response.Content.ReadAsStringAsync();
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
