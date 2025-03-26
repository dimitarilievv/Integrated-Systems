using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Domain.DomainModels
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Semester { get; set; }

    }
}
