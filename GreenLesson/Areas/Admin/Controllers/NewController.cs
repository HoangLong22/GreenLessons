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
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [HasCredential(RoleID = "ADD_NEW")]
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
        [HasCredential(RoleID = "EDIT_NEW")]
        public ActionResult Edit(int id)
        {
            var news = new NewDao().ViewDeatil(id);
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [HasCredential(RoleID = "EDIT_NEW")]
        public ActionResult Edit(New news)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewDao();
                
                var result = dao.Update(news);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "New");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        [HasCredential(RoleID = "DELETE_NEW")]
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
            New news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

    }
}