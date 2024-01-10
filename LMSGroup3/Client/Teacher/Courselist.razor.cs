using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using LMSGroup3.Shared.Domain.DTOs;
using Microsoft.AspNetCore.Components;

namespace LMSGroup3.Client.Teacher
{
    public partial class Courselist : ComponentBase
    {
        private List<CourseDto> courses;
        private List<ModuleDto> modules;
        private List<ActivityDto> activities;
        private ModuleDto moduleWithActivities;
        private int selectedCourseId;
        private int selectedModuleId;

        protected override async Task OnInitializedAsync()
        {
            await LoadCourses();
        }

        private async Task LoadCourses()
        {
            courses = await HttpClient.GetFromJsonAsync<List<CourseDto>>("api/Course/GetCourses");
        }

        private async Task LoadModules(int courseId)
        {
            selectedCourseId = courseId;
            modules = await HttpClient.GetFromJsonAsync<List<ModuleDto>>($"api/Course/GetModulesByCourse/{courseId}");
            StateHasChanged(); 
        }

        private async Task LoadActivities(int moduleId)
        {
            selectedModuleId = moduleId;
            moduleWithActivities = modules.FirstOrDefault(m => m.ModuleId == moduleId);
            activities = await HttpClient.GetFromJsonAsync<List<ActivityDto>>($"api/Course/GetActivitiesByModule/{moduleId}");
            StateHasChanged(); 
        }

       
        
        //private List<CourseDto> courses;

        //protected override async Task OnInitializedAsync()
        //{
        //    courses = await HttpClient.GetFromJsonAsync<List<CourseDto>>("api/Course/GetCourses");
        //}
    }
}