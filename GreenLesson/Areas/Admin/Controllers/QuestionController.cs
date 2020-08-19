using ExcelDataReader;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GreenLesson.Areas.Admin.Controllers
{
    public class QuestionController : BaseController
    {
        private GreenLessonDbContext db = new GreenLessonDbContext();
        // GET: Admin/Question
        public QuestionController()
        {
            db = new GreenLessonDbContext();
        }
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new QuestionDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public ActionResult Import()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import(HttpPostedFileBase postedFile)
        {
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);
                string conString = string.Empty;
                switch (extension)
                {
                    case ".xls": //Excel 97-03.
                        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07 and above.
                        conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break;
                }
                DataTable dt = new DataTable();
                conString = string.Format(conString, filePath);
                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            cmdExcel.Connection = connExcel;
                            //Get the name of First Sheet.
                            connExcel.Open();
                            DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            connExcel.Close();
                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();
                        }
                    }
                }
                conString = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "Question";
                        //[OPTIONAL]: Map the Excel columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("ID", "ID");
                        sqlBulkCopy.ColumnMappings.Add("CourseName", "CourseName");
                        sqlBulkCopy.ColumnMappings.Add("CategoryQuestion", "CategoryQuestion");
                        sqlBulkCopy.ColumnMappings.Add("Unit", "Unit");
                        sqlBulkCopy.ColumnMappings.Add("Image", "Image");
                        sqlBulkCopy.ColumnMappings.Add("Content", "Content");
                        sqlBulkCopy.ColumnMappings.Add("Answer1", "Answer1");
                        sqlBulkCopy.ColumnMappings.Add("Answer2", "Answer2");
                        sqlBulkCopy.ColumnMappings.Add("Answer3", "Answer3");
                        sqlBulkCopy.ColumnMappings.Add("Answer4", "Answer4");
                        sqlBulkCopy.ColumnMappings.Add("CorrectAnswer", "CorrectAnswer");
                        sqlBulkCopy.ColumnMappings.Add("CreatedDate", "CreatedDate");
                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBags();
            SetViewBag1();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Content,Unit,Image,CategoryQuestion,CourseName,Answer1,Answer2,Answer3,Answer4,CorrectAnswer")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SetViewBags();
            SetViewBag1();
            return View(question);
        }

        public void SetViewBag1(long? selectedId = null)
        {
            var dao = new CourseDao();
            ViewBag.CourseName = new SelectList(dao.ListAll(), "Name", "Name", selectedId);

        }
        public void SetViewBags(long? selectedId = null)
        {
            var dao = new CategoryQuestionDao();
            ViewBag.CategoryQuestion = new SelectList(dao.ListAllCateQues(), "Name", "Name", selectedId);

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new QuestionDao().Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        public ActionResult Edit(int id)
        {
            var lesson = new QuestionDao().ViewDeatil(id);
            SetViewBags();
            return View(lesson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                var dao = new QuestionDao();

                var result = dao.UpdateQues(question);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "Lesson");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            SetViewBags();
            
            return View("Index");
        }
    }
}