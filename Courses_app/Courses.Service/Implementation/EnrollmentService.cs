using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Courses.Domain.DomainModels;
using Courses.Repository.Interface;
using Courses.Service.Interface;

namespace Courses.Service.Implementation
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IRepository<Enrollment> _enrollmentRepository;

        public EnrollmentService(IRepository<Enrollment> enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public Enrollment DeleteById(Guid id)
        {
            var enrollment = GetById(id);
            if (enrollment == null)
            {
                throw new Exception("Enrollment not found");
            }
            _enrollmentRepository.Delete(enrollment);
            return enrollment;
        }

        public List<Enrollment> GetAll()
        {
            return _enrollmentRepository.GetAll(selector: x => x).ToList();
        }

        public Enrollment? GetById(Guid id)
        {
            return _enrollmentRepository.Get(selector: x => x,
                                          predicate: x => x.Id.Equals(id));
        }

        public Enrollment Insert(Enrollment enrollment)
        {
            enrollment.Id = Guid.NewGuid();
            return _enrollmentRepository.Insert(enrollment);
        }

        public Enrollment Update(Enrollment enrollment)
        {
            return _enrollmentRepository.Update(enrollment);
        }
    }
}
