﻿using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GreenLesson.Areas.Admin.Controllers
{
    public class LessonController : BaseController
    {
        private GreenLessonDbContext db = new GreenLessonDbContext();
        // GET: Admin/New
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new LessonDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBags();
            SetViewBag();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Name,Description,MetaTitle,CategoryName,Image,UserBy,Content,Status")] Lesson lessons)
        {
            if (ModelState.IsValid)
            {
                db.Lessons.Add(lessons);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SetViewBags();
            SetViewBag();
            return View(lessons);
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new UserDao();
            ViewBag.UserBy = new SelectList(dao.ListAll(), "Name", "Name", selectedId);

        }

        public void SetViewBags(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryName = new SelectList(dao.ListAll(), "Name", "Name", selectedId);

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new NewDao().Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

    }
}