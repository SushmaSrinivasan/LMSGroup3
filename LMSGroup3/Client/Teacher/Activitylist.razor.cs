using LMSGroup3.Shared.Domain.DTOs;
using System.Net.Http.Json;

namespace LMSGroup3.Client.Teacher
{
    public partial class Activitylist
    {
        private List<ActivityDto> activities;
        private int moduleId = 5;

        protected override async Task OnInitializedAsync()
        {
            activities = await HttpClient.GetFromJsonAsync<List<ActivityDto>>($"api/Activity/GetActivities?moduleId={moduleId}");
        }
    }
}