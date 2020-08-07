using Model.Dao;
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
            SetViewBag1();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Name,Description,MetaTitle,CourseName,CategoryName,Image,UserBy,Content,Status")] Lesson lessons)
        {
            if (ModelState.IsValid)
            {
                db.Lessons.Add(lessons);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SetViewBags();
            SetViewBag();
            SetViewBag1();
            return View(lessons);
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new UserDao();
            ViewBag.UserBy = new SelectList(dao.ListAll(), "Name", "Name", selectedId);

        }

        public void SetViewBag1(long? selectedId = null)
        {
            var dao = new CourseDao();
            ViewBag.CourseName = new SelectList(dao.ListAll(), "Name", "Name", selectedId);

        }

        public void SetViewBags(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryName = new SelectList(dao.ListAll(), "Name", "Name", selectedId);

        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new LessonDao().Delete(id);
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

        public ActionResult Edit(int id)
        {
            var lesson = new LessonDao().ViewDeatil(id);
            SetViewBags();
            SetViewBag();
            SetViewBag1();
            return View(lesson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                var dao = new LessonDao();

                var result = dao.Update1(lesson);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "Lesson");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            SetViewBags();
            SetViewBag();
            SetViewBag1();
            return View("Index");
        }

    }
}