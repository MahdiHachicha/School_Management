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
    public class StudentController : Controller
    {
        readonly IStudentRepository studentrepository;
        readonly ICourseRepository courseRpository;
        
        public StudentController(IStudentRepository studentrepository, ICourseRepository courseRpository)
        {
            this.studentrepository = studentrepository;
            this.courseRpository = courseRpository;
        }
        public ActionResult Search(string name, int? courseid)
        {
            var result = studentrepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = studentrepository.FindByName(name);
            else
            if (courseid != null)
                result = studentrepository.GetStudentsByCourseID(courseid);
            ViewBag.CourseId = new SelectList(courseRpository.GetAll(), "CourseId", "CourseName");
            return View("Index", result);
        }

        // GET: StudentController
        public ActionResult Index()
        {
            ViewBag.CourseId = new SelectList(courseRpository.GetAll(), "CourseId", "CourseName");
            return View(studentrepository.GetAll());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var courselist = studentrepository.GetStudentCourses(id);
            ViewBag.CoursesList = courselist;
            ViewBag.sizeList = courselist.Count();
            return View(studentrepository.GetById(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(courseRpository.GetAll(), "CourseId", "CourseName");
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student s)
        {
            try
            {
                ViewBag.CourseId = new SelectList(courseRpository.GetAll(), "CourseId", "CourseName");
                studentrepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CourseId = new SelectList(courseRpository.GetAll(), "CourseId", "CourseName");
            return View(studentrepository.GetById(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student s)
        {
            try
            {
                ViewBag.CourseId = new SelectList(courseRpository.GetAll(), "CourseId", "CourseName");
                studentrepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(studentrepository.GetById(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student s)
        {
            try
            {
                studentrepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
