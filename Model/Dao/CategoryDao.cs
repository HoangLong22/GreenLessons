using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryDao
    {
        GreenLessonDbContext db = null;
        public CategoryDao()
        {
            db = new GreenLessonDbContext();
        }

        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).Take(4).ToList();
        }

        public List<Category> ListAll1()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }

        public IEnumerable<Category> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public Category GetById(string Name)
        {
            return db.Categories.SingleOrDefault(x => x.Name == Name);
        }

        public Category ViewDeatil(long id)
        {
            return db.Categories.Find(id);
        }
        public bool UpdateCate(Category entity)
        {
            try
            {
                var categories = db.Categories.Find(entity.ID);
                categories.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    categories.Name = entity.Name;
                }

                categories.MetaTitle = entity.MetaTitle;
                categories.UserBy = entity.UserBy;
                categories.Status = entity.Status;
                categories.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var categories = db.Categories.Find(id);
                db.Categories.Remove(categories);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ChangeStatusCategory(long id)
        {
            var category = db.Categories.Find(id);
            category.Status = !category.Status;
            db.SaveChanges();
            return category.Status;
        }
    }
}
