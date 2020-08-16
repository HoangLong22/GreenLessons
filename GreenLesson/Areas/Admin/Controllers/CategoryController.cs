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
    public class CategoryController : BaseController
    {
        private GreenLessonDbContext db = new GreenLessonDbContext();
        // GET: Admin/Course
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new CategoryDao();
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
        public ActionResult Create([Bind(Include = "ID,Name,MetaTitle,CreatedBy,Status")] Category categories)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SetViewBag();
            return View(categories);
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new UserDao();
            ViewBag.UserBy = new SelectList(dao.ListAll(), "UserName", "Name", selectedId);

        }

        public ActionResult Edit(int id)
        {
            var categories = new CategoryDao().ViewDeatil(id);
            SetViewBag();
            return View(categories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Category categories)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();

                var result = dao.UpdateCate(categories);
                if (result)
                {
                    
                    return RedirectToAction("Index", "Category");
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
            new CategoryDao().Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category categories = db.Categories.Find(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }
        public JsonResult ChangeStatusCategory(long id)
        {
            var result = new CategoryDao().ChangeStatusCategory(id);
            return Json(new
            {
                status = result
            });
        }
    }
}