using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ExamDao
    {
        GreenLessonDbContext db = null;
        public ExamDao()
        {
            db = new GreenLessonDbContext();
        }

        public List<Exam> ListAll()
        {
            return db.Exams.Where(x => x.Status == true).Take(4).ToList();
        }

        public object Take(int v)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exam> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Exam> model = db.Exams;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Description.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public Exam GetById(string Name)
        {
            return db.Exams.SingleOrDefault(x => x.Name == Name);
        }
        public Exam ViewDeatil(long id)
        {
            return db.Exams.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var exams = db.Exams.Find(id);
                db.Exams.Remove(exams);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateExam(Exam entity)
        {
            try
            {
                var exams = db.Exams.Find(entity.ID);
                exams.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    exams.Name = entity.Name;
                }
                exams.Description = entity.Description;
                exams.MetaTitle = entity.MetaTitle;
                exams.Image = entity.Image;
                exams.UserBy = entity.UserBy;
                //exams.CategoryName = entity.CategoryName;
                exams.CourseName = entity.CourseName;
                exams.Content = entity.Content;
                exams.Status = entity.Status;
                exams.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
