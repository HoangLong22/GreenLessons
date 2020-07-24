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
    }
}