using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenLesson.Areas.Admin.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Admin/Contact
        public ActionResult Index()
        {
            return View();
        }
    }
}