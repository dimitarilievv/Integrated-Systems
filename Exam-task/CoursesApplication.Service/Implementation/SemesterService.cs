using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesApplication.Domain.DomainModels;
using CoursesApplication.Repository.Interface;
using CoursesApplication.Service.Interface;

namespace CoursesApplication.Service.Implementation
{
    public class SemesterService : ISemesterService
    {
        private readonly IRepository<Semester> _semesterRepository;

        public SemesterService(IRepository<Semester> semesterRepository)
        {
            _semesterRepository = semesterRepository;
        }

        public Semester DeleteById(Guid id)
        {
            var semester = _semesterRepository.Get(selector: x => x,
                                                predicate: x => x.Id == id);
            return _semesterRepository.Delete(semester);
        }

        public List<Semester> GetAll()
        {
            return _semesterRepository.GetAll(selector: x => x)
                .ToList();
        }

        public Semester? GetById(Guid id)
        {
            return _semesterRepository.Get(selector: x => x,
                                         predicate: x => x.Id == id);
        }

        public Semester Insert(Semester semester)
        {
            semester.Id = Guid.NewGuid();
            return _semesterRepository.Insert(semester);
        }

        public ICollection<Semester> InsertMany(ICollection<Semester> semesters)
        {
            return _semesterRepository.InsertMany(semesters);
        }

        public Semester Update(Semester semester)
        {
            return _semesterRepository.Update(semester);
        }
    }
}
