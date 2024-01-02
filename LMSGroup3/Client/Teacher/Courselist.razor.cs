using System.Net.Http.Json;
using LMSGroup3.Shared.Domain.DTOs;

namespace LMSGroup3.Client.Teacher
{
    public partial class Courselist
    {

        private List<CourseDto> courses;

        protected override async Task OnInitializedAsync()
        {
            courses = await HttpClient.GetFromJsonAsync<List<CourseDto>>("course/GetCourses");
        }
    }
}