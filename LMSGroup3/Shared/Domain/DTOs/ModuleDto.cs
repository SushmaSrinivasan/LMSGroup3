using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSGroup3.Shared.Domain.DTOs
{
    public class ModuleDto
    {
        public int Id { get; set; }
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CourseId { get; set; }

    }
}
