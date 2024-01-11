using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LMSGroup3.Shared.Domain.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        // Navigation Property
        //public ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();

        public ICollection<ModuleDto> Modules { get; set; } = new List<ModuleDto>();
    }
}
