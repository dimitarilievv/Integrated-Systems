using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Domain.DTO
{
    public class EnrollOnCourseDTO
    {
        public Guid SemesterId { get; set; }
        public Guid CourseId { get; set; }
        public bool ReEnroll { get; set; }
    }
}
