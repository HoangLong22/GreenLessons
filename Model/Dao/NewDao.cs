
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Model.EF;
namespace Model.Dao
{
    public class NewDao
    {
        GreenLessonDbContext db = null;
        public NewDao()
        {
            db = new GreenLessonDbContext();
        }
        //public long Insert(New entity)
        //{
        //    db.News.Add(entity);
        //    db.SaveChanges();
        //    return entity.ID;
        //}
        public bool Update(New entity)
        {
            try
            {
                var news = db.News.Find(entity.ID);
                news.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    news.Name = entity.Name;
                }
                news.Description = entity.Description;
                news.MetaTitle = entity.MetaTitle;
                news.Image = entity.Image;
                news.UserBy = entity.UserBy;
                news.Content = entity.Content;
                news.Status = entity.Status;
                news.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public IEnumerable<New> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<New> model = db.News;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Description.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public New GetById(string Name)
        {
            return db.News.SingleOrDefault(x => x.Name == Name);
        }

        public List<New> ListAll()
        {
            return db.News.Where(x => x.Status == true).Take(4).ToList();
        }

        public New ViewDeatil(long id)
        {
            return db.News.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var news = db.News.Find(id);
                db.News.Remove(news);
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
