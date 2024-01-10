using LMSGroup3.Shared.Domain.DTOs;
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Net.WebSockets;
using LMSGroup3.Client.Helpers;
using LMSGroup3.Client.Services;


namespace LexiconLMS.Client.Pages
{
    public partial class ModuleAdd : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public IGenericDataService GenericDataService { get; set; } = default!;

        [Parameter]
        public int CourseId { get; set; }

        public ModuleDto Module { get; set; } = new ModuleDto();

        public string ErrorMessage { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
           base.OnInitializedAsync();
        }

        private async Task HandleValidSubmit()
        {
            try
            {
                Module.CourseId = CourseId;
                if (await GenericDataService.AddAsync(UriHelpers.GetModulesUri(), Module))
                {
                    NavigationManager.NavigateTo("/api/courses");
                }
                else
                {
                    ErrorMessage = "Could not add module";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"{ex.Message} {ex.HResult}";
            }
        }
    }
}