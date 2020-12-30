using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETProject.Models;
using ASPNETProject.Models.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETProject.Controllers
{
    public class TeacherController : Controller
    {
        readonly ITeacherRepository teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        // GET: TeacherController
        public ActionResult Index()
        {
            return View(teacherRepository.GetAll());
        }

        // GET: TeacherController/Details/5
        public ActionResult Details(int id)
        {
            return View(teacherRepository.GetById(id));
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher t)
        {
            try
            {
                teacherRepository.Add(t);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(teacherRepository.GetById(id));
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher t)
        {
            try
            {
                teacherRepository.Edit(t);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(teacherRepository.GetById(id));
        }

        // POST: TeacherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Teacher t)
        {
            try
            {
                teacherRepository.Delete(t);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
