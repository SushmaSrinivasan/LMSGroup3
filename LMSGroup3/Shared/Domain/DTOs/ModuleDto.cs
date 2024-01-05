using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSGroup3.Shared.Domain.DTOs
{
    public class ModuleDto
    {
        public int Id { get; set; }

        public string ModuleName { get; set; } = string.Empty;

        public string ModuleDescription { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CourseId { get; set; }

        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    }
}
