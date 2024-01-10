using LMSGroup3.Shared.Domain.DTOs;
using LMSGroup3.Shared.DTOs;
using System.Net.Http.Json;

namespace LMSGroup3.Client.Student
{
    public partial class Classmates
    {
        private List<ApplicationUserDto> studentcourses;
        private string studentId;

        protected override async Task OnInitializedAsync()
        {
            // var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            // var user = authState.User;

            studentId = "2f94dfbd-f989-4367-831e-294470045df1";

            if (!string.IsNullOrEmpty(studentId))
            {
                await LoadStudentsInSameCourse(studentId);
            }
        }

        private async Task LoadStudentsInSameCourse(string studentId)
        {
            studentcourses = await HttpClient.GetFromJsonAsync<List<ApplicationUserDto>>($"api/Student/GetStudentsInSameCourse/{studentId}");
        }
    }
}