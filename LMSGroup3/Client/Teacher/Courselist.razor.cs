using System.Net.Http.Json;
using LMSGroup3.Shared.Domain.DTOs;

namespace LMSGroup3.Client.Teacher
{
    public partial class Courselist
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
            moduleWithActivities = modules.FirstOrDefault(m => m.Id == moduleId);
            activities = await HttpClient.GetFromJsonAsync<List<ActivityDto>>($"api/Course/GetActivitiesByModule/{moduleId}");
            StateHasChanged();
        }
    }
}