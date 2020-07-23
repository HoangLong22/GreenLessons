using GreenLesson.Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace GreenLesson.Areas.Admin.Controllers
{
    public class NewController : BaseController
    {
        private GreenLessonDbContext db = new GreenLessonDbContext();
        // GET: Admin/New
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new NewDao();
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

        //[HttpPost]
        //[ValidateInput(false)]

        //public ActionResult Create(New news)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new NewDao();
        //        long id = dao.Insert(news);
        //        if (id > 0)
        //        {
        //            return RedirectToAction("Index", "New");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Thêm mới thành công");
        //        }
        //    }
        //    return View("Index");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Name,Description,MetaTitle,Image,UserBy,Content,Status")] New news)
        {
            if (ModelState.IsValid)
            {
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SetViewBag();
            return View(news);
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new UserDao();
            ViewBag.UserBy = new SelectList(dao.ListAll(),"Name", "Name", selectedId);

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new NewDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}