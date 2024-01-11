using LMSGroup3.Client.Teacher;
using LMSGroup3.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using LMSGroup3.Shared.Domain.DTOs;
using static LMSGroup3.Client.Teacher.ViewStudents;
using LMSGroup3.Shared.DTOs;


namespace LMSGroup3.Client.Teacher
{
    public partial class ViewStudents : ComponentBase
    {
        [Parameter]
        public int courseId { get; set; }


        public List<ApplicationUserDto> viewstudents;

        protected override async Task OnInitializedAsync()
        {
            await LoadCourses();
        }

        private async Task LoadCourses()
        {
            viewstudents = await HttpClient.GetFromJsonAsync<List<ApplicationUserDto>>($"api/Student/GetStudentsInCourse/{courseId}");
        }

    }
}