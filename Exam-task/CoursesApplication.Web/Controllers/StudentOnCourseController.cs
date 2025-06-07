using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoursesApplication.Domain.DomainModels;
using CoursesApplication.Repository.Data;
using CoursesApplication.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using CoursesApplication.Service.Implementation;
using CoursesApplication.Domain.DTO;

namespace CoursesApplication.Web.Controllers
{
    [Authorize]
    public class StudentOnCourseController : Controller
    {
        private readonly IStudentOnCourseService studentOnCourseService;
        private readonly ISemesterService semesterService;

        public StudentOnCourseController(IStudentOnCourseService studentOnCourseService, ISemesterService semesterService)
        {
            this.studentOnCourseService = studentOnCourseService;
            this.semesterService = semesterService;
        }

        // GET: StudentOnCourse
        // Enrolled Courses Page
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var studentOnCourse = studentOnCourseService.GetAllByPassengerId(userId);
            return View(studentOnCourse);
        }

        public IActionResult EnrollOnCourse(Guid courseId)
        {
            ViewData["SemesterId"] = new SelectList(semesterService.GetAll(), "Id", "Name");
            ViewData["CourseId"] = courseId;
            return View();
        }

        [HttpPost]
        public IActionResult SubmitCourseEnrollemnt(EnrollOnCourseDTO enrollOnCourseDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            studentOnCourseService.EnrollOnCourse(userId,enrollOnCourseDTO.CourseId, enrollOnCourseDTO.SemesterId, enrollOnCourseDTO.ReEnroll);
            return RedirectToAction("Index");
        }
    }
}
