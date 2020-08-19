using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
   
    public class CategoryQuestionDao
    {
        GreenLessonDbContext db = null;
        public CategoryQuestionDao()
        {
            db = new GreenLessonDbContext();
        }

        public List<CategoryQuestion> ListAllCateQues()
        {
            return db.CategoryQuestions.Where(x => x.Status == true).ToList();
        }
    }
}
