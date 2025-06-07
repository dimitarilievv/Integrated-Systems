using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesApplication.Domain.DomainModels;
using CoursesApplication.Repository.Interface;
using CoursesApplication.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoursesApplication.Service.Implementation
{
    public class StudentOnCourseService : IStudentOnCourseService
    {
        private readonly IRepository<StudentOnCourse> _studentOnCourseRepository;
        private readonly ISemesterService _semesterService;
        private readonly ICourseService _courseService;
        private readonly IStudentRepository _studentRepository;

        public StudentOnCourseService(IRepository<StudentOnCourse> studentOnCourseRepository, ICourseService courseService, ISemesterService semesterService, IStudentRepository studentRepository)
        {
            _studentOnCourseRepository = studentOnCourseRepository;
            _courseService = courseService;
            _semesterService = semesterService;
            _studentRepository = studentRepository;
        }

        public StudentOnCourse DeleteById(Guid id)
        {
            var studentOnCourse = _studentOnCourseRepository.Get(selector: x => x,
                                                predicate: x => x.Id == id);
            return _studentOnCourseRepository.Delete(studentOnCourse);
        }

        public StudentOnCourse EnrollOnCourse(string studentId, Guid courseId, Guid semesterId, bool reEnrolled)
        {
            var course = _courseService.GetById(courseId);
            var semester = _semesterService.GetById(semesterId);
            var student = _studentRepository.GetById(studentId);
            var studentOnCourse = new StudentOnCourse()
            {
                Id = Guid.NewGuid(),
                StudentId = studentId,
                CourseId = courseId,
                SemesterId = semesterId,
                ReEnrollment = reEnrolled,
                Course = course,
                Semester = semester,
                Student = student
            };
            _studentOnCourseRepository.Insert(studentOnCourse);
            return studentOnCourse;
        }

        public List<StudentOnCourse> GetAll()
        {
            return _studentOnCourseRepository.GetAll(selector: x => x)
                .ToList();
        }

        public List<StudentOnCourse> GetAllByPassengerId(string studentId)
        {
            return _studentOnCourseRepository.GetAll(selector: x => x,
                                          predicate: x => x.StudentId.Equals(studentId),
                                          include: x => x.Include(z => z.Semester)
                                                          .Include(z => z.Student)
                                                          .Include(z => z.Course)



                                          ).ToList();
        }

        public StudentOnCourse? GetById(Guid id)
        {
            return _studentOnCourseRepository.Get(selector: x => x,
                                          predicate: x => x.Id.Equals(id),
                                          include: x => x.Include(z => z.Semester)
                                                          .Include(z => z.Student)
                                                          .Include(z => z.Course)



                                          );
        }

        public StudentOnCourse Insert(StudentOnCourse studentOnCourse)
        {
            studentOnCourse.Id = Guid.NewGuid();
            return _studentOnCourseRepository.Insert(studentOnCourse);
        }

        public StudentOnCourse Update(StudentOnCourse studentOnCourse)
        {
            return _studentOnCourseRepository.Update(studentOnCourse);
        }
    }
}
