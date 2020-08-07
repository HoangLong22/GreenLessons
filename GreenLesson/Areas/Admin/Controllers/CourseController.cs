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
    public class CourseController : BaseController
    {
        private GreenLessonDbContext db = new GreenLessonDbContext();
        // GET: Admin/Course
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new CourseDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Name,MetaTitle,UserBy,Status")] Course courses)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SetViewBag();
            return View(courses);
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new UserDao();
            ViewBag.UserBy = new SelectList(dao.ListAll(), "UserName", "Name", selectedId);

        }

        public ActionResult Edit(int id)
        {
            var courses = new CourseDao().ViewDeatil(id);
            SetViewBag();
            return View(courses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Course courses)
        {
            if (ModelState.IsValid)
            {
                var dao = new CourseDao();

                var result = dao.UpdateCourse(courses);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "Course");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            SetViewBag();
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CourseDao().Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }
    }
}