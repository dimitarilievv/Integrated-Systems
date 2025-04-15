using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Domain.DomainModels;

namespace Courses.Service.Interface
{
    public interface IEnrollmentService
    {
        List<Enrollment> GetAll();
        Enrollment? GetById(Guid id);
        Enrollment DeleteById(Guid id);
        Enrollment Insert(Enrollment enrollment);
        Enrollment Update(Enrollment enrollment);
    }
}
