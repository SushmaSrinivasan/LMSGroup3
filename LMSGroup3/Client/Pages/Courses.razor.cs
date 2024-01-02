using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Json;
using LMSGroup3.Shared.Domain.Models;

namespace LMSGroup3.Client.Pages
{
    public partial class Courses
    {
        private Course[]? courses;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                courses = await Http.GetFromJsonAsync < Course[] >("api/Course/GetAllCourses");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

    }
}