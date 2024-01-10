using LMSGroup3.Shared.Domain.DTOs;
using System.Net.Http.Json;
using System.Reflection;

namespace LMSGroup3.Client.Student
{
    public partial class StudentCourseList
    {
        private CourseDto studentcourse;
        private string studentId;
        private List<ModuleDto> modules;
        private List<ActivityDto> activities;
        private ModuleDto moduleWithActivities;
        private int selectedCourseId;
        private int selectedModuleId;
        protected override async Task OnInitializedAsync()
        {
            // var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            // var user = authState.User;

            studentId = "2f94dfbd-f989-4367-831e-294470045df1";
            //studentcourse = await HttpClient.GetFromJsonAsync<CourseDto>($"api/Student/GetCourseForStudent/{studentId}");

            if (!string.IsNullOrEmpty(studentId))
            {
                await LoadStudentCourses(studentId);
            }
        }

        private async Task LoadStudentCourses(string studentId)
        {
            studentcourse = await HttpClient.GetFromJsonAsync<CourseDto>($"api/Student/GetCourseForStudent/{studentId}");
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