using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Microsoft.Ajax.Utilities;

namespace GreenLesson.Controllers
{
    public class NewController : Controller
    {
        // GET: New
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult New()
        {
            var model = new NewDao().ListAll();
            return PartialView(model);
        }
    }
}