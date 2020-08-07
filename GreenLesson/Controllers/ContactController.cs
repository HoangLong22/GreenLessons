using Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace GreenLesson.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = new ContactDao().GetActiveContact();
            return View(model);
        }

        [HttpPost]
        public JsonResult Send(string name, string phone, string email, string address, string content)
        {
            var feedback = new Feedback();
            feedback.Name = name;
            feedback.Phone = phone;
            feedback.Email = email;
            feedback.Address = address;
            feedback.Content = content;
            var id = new ContactDao().InsertFeedback(feedback);
            if (id > 0)
            {
                string contents = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Client/template/feedback.html"));
                contents = contents.Replace("{{Name}}", name);
                contents = contents.Replace("{{Phone}}", phone);
                contents = contents.Replace("{{Email}}", email);
                contents = contents.Replace("{{Address}}", address);
                contents = contents.Replace("{{Content}}", content);
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                new MailHelper().SendEmail(email, "Feedback của bạn cho GreenLesson", contents);
                new MailHelper().SendEmail(toEmail, "Feedback của bạn cho GreenLesson", contents);

                return Json(new
                {
                    status = true
                });
                ///Send Mail
               
            }
            else
                return Json(new
                {
                    status = false
                });
        }
    }
}