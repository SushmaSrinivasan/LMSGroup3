using LMSGroup3.Client.Teacher;
using LMSGroup3.Shared.Domain.DTOs;
using Microsoft.AspNetCore.Components;

namespace LMSGroup3.Client.Pages
{
	public partial class ManageCourse : ComponentBase
	{
		public List<CourseDto> Courses { get; set; } = default!; //Need to implement the 
													 //stored courses from the databases

		protected override void OnInitialized()
		{
			//CourseDto = new CourseDto();  (I am unsure how to get the courses from the database
		}
	}
}
