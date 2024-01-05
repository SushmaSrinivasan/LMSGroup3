using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSGroup3.Shared.Domain.DTOs
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public string ActivityDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ModuleId { get; set; }

        public int ActivityTypeId { get; set; }

    }
}
