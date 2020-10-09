using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace GreenLesson.Controllers
{
    public class LessonController : Controller
    {
        // GET: Lesson
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Lesson()
        {
            var model = new LessonDao().ListAll();
            return PartialView(model);
        }

        public ActionResult Detail(long id)
        {
            var news = new LessonDao().ViewDeatil(id);
            return PartialView(news);
        }

        public JsonResult ListName(string q)
        {
            var data = new LessonDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            },JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string query, int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var model = new LessonDao().Search(query, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Keyword = query;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
    }
}