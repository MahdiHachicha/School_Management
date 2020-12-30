using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETProject.Models;
using ASPNETProject.Models.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNETProject.Controllers
{
    public class CourseController : Controller
    {
        readonly IStudentRepository studentrepository;
        readonly ICourseRepository courseRpository;
        readonly ITeacherRepository teacherRepository;

        public CourseController(ITeacherRepository teacherRepository,IStudentRepository studentrepository, ICourseRepository courseRpository)
        {
            this.studentrepository = studentrepository;
            this.courseRpository = courseRpository;
            this.teacherRepository = teacherRepository;
        }

        // GET: CourseController
        public ActionResult Index()
        {
            ViewBag.TeacherId = new SelectList(teacherRepository.GetAll(), "TeacherId", "FirstName","LastName");
            return View(courseRpository.GetAll());
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            //ViewBag.TeacherID = new SelectList(teacherRepository.GetAll(), "TeacherID", "FirstName", "LastName");
            return View(courseRpository.GetById(id));
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            ViewBag.TeacherId = new SelectList(teacherRepository.GetAllSummary(), "TeacherId", "Name");
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course c)
        {
            try
            {
                ViewBag.TeacherId = new SelectList(teacherRepository.GetAll(), "TeacherId", "FirstName", "LastName");
                courseRpository.Add(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.TeacherId = new SelectList(teacherRepository.GetAll(), "TeacherId", "FirstName", "LastName");

            return View(courseRpository.GetById(id));
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course c)
        {
            try
            {
                ViewBag.TeacherId = new SelectList(teacherRepository.GetAll(), "TeacherId", "FirstName", "LastName");

                courseRpository.Edit(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(courseRpository.GetById(id));
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Course c)
        {
            try
            {
                courseRpository.Delete(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
