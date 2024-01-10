using LMSGroup3.Shared.Domain.DTOs;
using System.Net.Http.Json;

namespace LMSGroup3.Client.Student
{
    public partial class Classmates
    {
        private List<StudentCoursesDto> studentcourses;
        private string studentId;

        protected override async Task OnInitializedAsync()
        {
            // var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            // var user = authState.User;

            studentId = "2f94dfbd-f989-4367-831e-294470045df1";
            //studentcourse = await HttpClient.GetFromJsonAsync<CourseDto>($"api/Student/GetCourseForStudent/{studentId}");

            if (!string.IsNullOrEmpty(studentId))
            {
                await LoadStudentsInSameCourse(studentId);
            }
        }

        private async Task LoadStudentsInSameCourse(string studentId)
        {
            studentcourses = await HttpClient.GetFromJsonAsync<List<StudentCoursesDto>>($"api/Student/GetStudentsInSameCourse/{studentId}");
        }
    }
}