using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSGroup3.Shared.Domain.DTOs
{
    public class StudentCoursesDto
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }

    }

}
