using LMSGroup3.Shared.Domain.DTOs;
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Net.WebSockets;
using LMSGroup3.Client.Helpers;
using System.Reflection;
using LMSGroup3.Shared.Entities;
using System.Net.Http.Json;

namespace LMSGroup3.Client.Pages
{
    public partial class ModuleAdd 
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        //[Inject]
        //public IGenericDataService GenericDataService { get; set; } = default!;

        [Parameter]
        public int CourseId { get; set; }

        public ModuleDto moduleDto { get; set; } = new ModuleDto();

        public CourseDto Course { get; set; } = new CourseDto();

        [Parameter]
        public string ErrorMessage { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Course = await Http.GetFromJsonAsync<CourseDto>($"api/Course/{CourseId}");
            base.OnInitializedAsync();
        }

        public async Task HandleValidSubmit()
        {
            try
            {
                moduleDto.CourseId = CourseId;
                var response = await Http.PostAsJsonAsync<ModuleDto>("api/Modules", moduleDto);
                if (response.IsSuccessStatusCode)
                {
                    NavigationManager.NavigateTo("/courses");
                } else
                {
                    ErrorMessage = "Could not add Module!";
                }
                
            }

            catch (Exception ex)
            {
                ErrorMessage = $"{ex.Message} {ex.HResult}";
            }
        }
    }
}