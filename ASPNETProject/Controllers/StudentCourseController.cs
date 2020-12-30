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
    public class StudentCourseController : Controller
    {
        readonly IStudentRepository studentrepository;
        readonly ICourseRepository courseRpository;
        readonly ITeacherRepository teacherRepository;
        readonly IStudentCourseRepository studentCourserepository;

        public StudentCourseController(IStudentCourseRepository studentCourseRepository,ITeacherRepository teacherRepository, IStudentRepository studentrepository, ICourseRepository courseRpository)
        {
            this.studentrepository = studentrepository;
            this.courseRpository = courseRpository;
            this.teacherRepository = teacherRepository;
            this.studentCourserepository = studentCourseRepository;
        }
        // GET: StudentCourseController
        public ActionResult Index()
        {
            ViewBag.StudentId = new SelectList(studentrepository.GetAll(), "StudentId", "FirstName", "LastName");
            ViewBag.CourseId = new SelectList(courseRpository.GetAll(), "CourseId", "CourseName");
            return View(studentCourserepository.GetAll());
        }

        // GET: StudentCourseController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.studentName = studentrepository.GetById(studentCourserepository.GetById(id).StudentId).FirstName 
                + " " +
                studentrepository.GetById(studentCourserepository.GetById(id).StudentId).LastName;
            ViewBag.CourseName = courseRpository.GetById(studentCourserepository.GetById(id).CourseId).CourseName;
            return View(studentCourserepository.GetById(id));
        }

        // GET: StudentCourseController/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(studentrepository.GetAll(), "StudentId", "FirstName", "LastName");
            ViewBag.CourseId = new SelectList(courseRpository.GetAll(), "CourseId", "CourseName");
            return View();
        }

        // POST: StudentCourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentCourse s)
        {
            try
            {
                ViewBag.StudentId = new SelectList(studentrepository.GetAll(), "StudentId", "FirstName", "LastName");
                ViewBag.CourseId = new SelectList(courseRpository.GetAll(), "CourseId", "CourseName");
                studentCourserepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentCourseController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.StudentId = new SelectList(studentrepository.GetAll(), "StudentId", "FirstName", "LastName");
            ViewBag.CourseId = new SelectList(courseRpository.GetAll(), "CourseId", "CourseName");
            return View(studentCourserepository.GetById(id));
        }

        // POST: StudentCourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentCourse s)
        {
            try
            {
                ViewBag.StudentId = new SelectList(studentrepository.GetAll(), "StudentId", "FirstName", "LastName");
                ViewBag.CourseId = new SelectList(courseRpository.GetAll(), "CourseId", "CourseName");
                studentCourserepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentCourseController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.studentName = studentrepository.GetById(studentCourserepository.GetById(id).StudentId).FirstName
                   + " " +
                   studentrepository.GetById(studentCourserepository.GetById(id).StudentId).LastName;
            ViewBag.CourseName = courseRpository.GetById(studentCourserepository.GetById(id).CourseId).CourseName;

            return View(studentCourserepository.GetById(id));
        }

        // POST: StudentCourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(StudentCourse s)
        {
            try
            {
                studentCourserepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
