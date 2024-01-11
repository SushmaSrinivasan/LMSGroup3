using LMSGroup3.Client.Teacher;
using LMSGroup3.Shared.Domain.DTOs;
using LMSGroup3.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LMSGroup3.Client.Pages
{
    public partial class ManageCourse
    {
        public List<CourseDto> Courses { get; set; } = default!; //Need to implement the 
                                                                 //stored courses from the databases

        protected override async Task OnInitializedAsync()
        {
            await LoadCourses();
        }

        private async Task LoadCourses()
        {
            Courses = await HttpClient.GetFromJsonAsync<List<CourseDto>>("api/Course/GetCourses");
        }
    }
}