using Microsoft.AspNetCore.Authorization;
using LMSGroup3.Shared.Domain.DTOs;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Net.Http.Json;
using System.Text;
using LMSGroup3.Client.Helpers;
using LMSGroup3.Client.Services;

namespace LMSGroup3.Client.Pages
{
    public partial class ModuleDelete
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public IGenericDataService GenericDataService { get; set; } = default!;

        [Parameter]
        public int? ModuleId { get; set; }

        public ModuleDto Module { get; set; } = new ModuleDto();

        public string ErrorMessage { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (ModuleId == null)
            {
                ErrorMessage = "Module not found";
                return;
            }

            Module = await GenericDataService.GetAsync<ModuleDto>(UriHelpers.GetModuleUri(ModuleId.Value)) ?? Module;

            if (Module == null)
            {
                ErrorMessage = "Module not found";
                return;
            }

            await base.OnInitializedAsync();
        }

        private async Task DeleteModule()
        {
            try
            {
                if (Module == null)
                {
                    return;
                }
                if (await GenericDataService.DeleteAsync(UriHelpers.GetModuleUri(Module.Id)))
                {
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    ErrorMessage = "Could not delete Module";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }






}
