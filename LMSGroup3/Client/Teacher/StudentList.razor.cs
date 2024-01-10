//using LMSGroup3.Shared.Domain.DTOs;
//using LMSGroup3.Shared.DTOs;
//using System.Net.Http.Json;

//namespace LMSGroup3.Client.Student
//{
//    public partial class StudentList
//    {
//        private List<ApplicationUserDto> studentlists;
//        private string studentId; // Not studentId?


//        protected override async Task OnInitializedAsync()
//        {
//            // var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
//            // var user = authState.User;

//            studentId = "2f94dfbd-f989-4367-831e-294470045df1"; // Change to dynamic value

//            if (!string.IsNullOrEmpty(studentId))
//            {
//                await LoadStudentsInCourse(studentId);
//            }
//        }

//        private async Task LoadStudentsInCourse(string studentId)
//        {
//            studentlists = await HttpClient.GetFromJsonAsync<List<ApplicationUserDto>>($"api/Student/GetStudentsInCourse/{studentId}");
//        }
//    }
//}