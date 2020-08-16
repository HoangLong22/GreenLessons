using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CourseDao
    {
        GreenLessonDbContext db = null;
        public CourseDao()
        {
            db = new GreenLessonDbContext();
        }

        public IEnumerable<Course> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Course> model = db.Courses;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public Course GetById(string Name)
        {
            return db.Courses.SingleOrDefault(x => x.Name == Name);
        }
        public List<Course> ListAll()
        {
            return db.Courses.Where(x => x.Status == true).ToList();
        }
        public Course ViewDeatil(long id)
        {
            return db.Courses.Find(id);
        }
        public bool UpdateCourse(Course entity)
        {
            try
            {
                var courses = db.Courses.Find(entity.ID);
                courses.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    courses.Name = entity.Name;
                }

                courses.MetaTitle = entity.MetaTitle;
                courses.UserBy = entity.UserBy;
                courses.Status = entity.Status;
                courses.ModifiedDate = DateTime.Now;
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
                var courses = db.Courses.Find(id);
                db.Courses.Remove(courses);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ChangeStatusCourse(long id)
        {
            var course = db.Courses.Find(id);
            course.Status = !course.Status;
            db.SaveChanges();
            return course.Status;
        }
    }
}
