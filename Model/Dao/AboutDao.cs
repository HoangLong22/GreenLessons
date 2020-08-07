using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class AboutDao
    {
        GreenLessonDbContext db = null;
        public AboutDao()
        {
            db = new GreenLessonDbContext();
        }

       
        public IEnumerable<About> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<About> model = db.Abouts;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Description.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        //public New GetById(string Name)
        //{
        //    return db.Abounts.SingleOrDefault(x => x.Name == Name);
        //}

        public List<About> ListAll()
        {
            return db.Abouts.Where(x => x.Status == true).Take(4).ToList();
        }

        public About ViewDetail(long id)
        {
            return db.Abouts.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var abouts = db.Abouts.Find(id);
                db.Abouts.Remove(abouts);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update2(About entity)
        {
            try
            {
                var abouts = db.Abouts.Find(entity.ID);
                abouts.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    abouts.Name = entity.Name;
                }
                abouts.Description = entity.Description;
                abouts.MetaTitle = entity.MetaTitle;
                abouts.Image = entity.Image;
                abouts.Detail = entity.Detail;
                abouts.Status = entity.Status;
                abouts.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public About GetActiveAbout()
        {
            return db.Abouts.Single(x => x.Status == true);
        }
    }
}
