using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Courses.Domain.DomainModels;
using Courses.Web.Data;
using Courses.Repository.Interface;
using Courses.Service.Interface;
using Courses.Service.Implementation;

namespace Courses.Web.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        // GET: Enrollments
        public IActionResult Index()
        {
            return View(_enrollmentService.GetAll());
        }

        // GET: Enrollments/Details/5
        public IActionResult Details(Guid id)
        {
            var enrollment = _enrollmentService.GetById(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,DateEnrolled,ReEnrolled,StudentId,CourseId")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _enrollmentService.Insert(enrollment);
                return RedirectToAction(nameof(Index));
            }
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public IActionResult Edit(Guid id)
        {
            var enrollment = _enrollmentService.GetById(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,DateEnrolled,ReEnrolled,StudentId,CourseId")] Enrollment enrollment)
        {
            if (id != enrollment.Id)
            {
                return NotFound();
            }

            _enrollmentService.Update(enrollment);


            return RedirectToAction(nameof(Index));
        }

        // GET: Enrollments/Delete/5
        public IActionResult Delete(Guid id)
        {
            var enrollment = _enrollmentService.GetById(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _enrollmentService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(Guid id)
        {
            var enrollment = _enrollmentService.GetById(id);
            if (enrollment == null)
            {
                return false;
            }
            return true;
        }
    }
}
