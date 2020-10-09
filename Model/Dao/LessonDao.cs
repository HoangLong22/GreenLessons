using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class LessonDao
    {
        GreenLessonDbContext db = null;
        public LessonDao()
        {
            db = new GreenLessonDbContext();
        }

        public List<Lesson> ListAll()
        {
            return db.Lessons.Where(x => x.Status == true).Take(4).ToList();
        }

        public object Take(int v)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lesson> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Lesson> model = db.Lessons;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Description.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public Lesson GetById(string Name)
        {
            return db.Lessons.SingleOrDefault(x => x.Name == Name);
        }
        public Lesson ViewDeatil(long id)
        {
            return db.Lessons.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var lessons = db.Lessons.Find(id);
                db.Lessons.Remove(lessons);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ChangeStatusLesson(long id)
        {
            var lesson = db.Lessons.Find(id);
            lesson.Status = !lesson.Status;
            db.SaveChanges();
            return lesson.Status;
        }
        public bool Update1(Lesson entity)
        {
            try
            {
                var lessons = db.Lessons.Find(entity.ID);
                lessons.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    lessons.Name = entity.Name;
                }
                lessons.Description = entity.Description;
                lessons.MetaTitle = entity.MetaTitle;
                lessons.Image = entity.Image;
                lessons.UserBy = entity.UserBy;
                lessons.CategoryName = entity.CategoryName;
                lessons.Content = entity.Content;
                lessons.Status = entity.Status;
                lessons.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<string> ListName(string query)
        {
            return db.Lessons.Where(x => x.Name.Contains(query)).Select(x => x.Name).ToList();
        }

        public List<Lesson> Search(string query, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Lessons.Where(x => x.Name == query).Count();
            var model = (from a in db.Lessons
                         join b in db.Categories
                         on a.ID equals b.ID
                         where a.Name.Contains(query)
                         select new
                         {
                            
                             CategoryName = b.Name,
                             CreatedDate = a.CreatedDate,
                             ID = a.ID,
                             Image = a.Image,
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                         }).AsEnumerable().Select(x => new Lesson()
                         {
                            
                             CategoryName = x.Name,
                             CreatedDate = x.CreatedDate,
                             ID = x.ID,
                             Image = x.Image,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                          
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
    }
}