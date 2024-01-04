using System.Net.Http.Json;
using LMSGroup3.Shared.Domain.DTOs;

namespace LMSGroup3.Client.Teacher
{
    public partial class Courselist
    {
        private List<CourseDto> courses;
        private List<ModuleDto> modules;
        private int selectedCourseId;

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
            StateHasChanged(); // Force the component to re-render
        }
        //private List<CourseDto> courses;

        //protected override async Task OnInitializedAsync()
        //{
        //    courses = await HttpClient.GetFromJsonAsync<List<CourseDto>>("api/Course/GetCourses");
        //}
    }
}