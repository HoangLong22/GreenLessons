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
    public class ExamController : BaseController
    {
        private GreenLessonDbContext db = new GreenLessonDbContext();
        // GET: Admin/Exam
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new ExamDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            SetViewBag1();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Name,Description,MetaTitle,CourseName,Image,UserBy,Content,Status")] Exam exams)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exams);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SetViewBag();
            SetViewBag1();
            return View(exams);
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new UserDao();
            ViewBag.UserBy = new SelectList(dao.ListAll(), "UserName", "Name", selectedId);

        }

        public void SetViewBag1(long? selectedId = null)
        {
            var dao = new CourseDao();
            ViewBag.CourseName = new SelectList(dao.ListAll(), "Name", "Name", selectedId);

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ExamDao().Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exams = db.Exams.Find(id);
            if (exams == null)
            {
                return HttpNotFound();
            }
            return View(exams);
        }

        public ActionResult Edit(int id)
        {
            var exams = new ExamDao().ViewDeatil(id);
            SetViewBag();
            SetViewBag1();
            return View(exams);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Exam exams)
        {
            if (ModelState.IsValid)
            {
                var dao = new ExamDao();

                var result = dao.UpdateExam(exams);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "Exam");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            SetViewBag();
            SetViewBag1();
            return View("Index");
        }
    }
}