using GreenLesson.Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Net;

namespace GreenLesson.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        private GreenLessonDbContext db = new GreenLessonDbContext();
        // GET: Admin/About
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new AboutDao();
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
        public ActionResult Create([Bind(Include = "ID,Name,Description,MetaTitle,Image,UserBy,Detail,Status")] About abouts)
        {
            if (ModelState.IsValid)
            {
                db.Abounts.Add(abouts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SetViewBag();
            return View(abouts);
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new UserDao();
            ViewBag.UserBy = new SelectList(dao.ListAll(), "Name", "Name", selectedId);

        }

        public ActionResult Edit(int id)
        {
            var abouts = new AboutDao().ViewDetail(id);
            return View(abouts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(About abouts)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDao();

                var result = dao.Update(abouts);
                if (result)
                {
                    //SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "About");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }

       

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new AboutDao().Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About abouts = db.Abounts.Find(id);
            if (abouts == null)
            {
                return HttpNotFound();
            }
            return View(abouts);
        }
    }
}