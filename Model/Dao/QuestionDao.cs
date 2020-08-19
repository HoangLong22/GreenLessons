using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class QuestionDao
    {
        GreenLessonDbContext db = null;
        public QuestionDao()
        {
            db = new GreenLessonDbContext();
        }

        public IEnumerable<Question> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Question> model = db.Questions;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Content.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool Delete(int id)
        {
            try
            {
                var question = db.Questions.Find(id);
                db.Questions.Remove(question);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public List<Question> ListAllQues()
        //{
        //    var questions = db.Questions
        //          .OrderBy(c => Guid.NewGuid())
        //          .FirstOrDefault();
        //    return questions;
        //}
        public Question ViewDeatil(long id)
        {
            return db.Questions.Find(id);
        }
       
        public bool UpdateQues(Question entity)
        {
            try
            {
                var questions = db.Questions.Find(entity.ID);
                questions.Content = entity.Content;
                if (!string.IsNullOrEmpty(entity.Content))
                {
                    questions.Content = entity.Content;
                }
                questions.CategoryQuestion = entity.CategoryQuestion;
                questions.Image = entity.Image;
                questions.Unit = entity.Unit;
                questions.Answer1 = entity.Answer1;
                questions.Answer2 = entity.Answer2;
                questions.Answer3 = entity.Answer3;
                questions.Answer4 = entity.Answer4;
                questions.CorrectAnswer = entity.CorrectAnswer;
                questions.C = DateTime.Now;
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
