using Model.EF;
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

        public About ViewDetail(long id)
        {
            return db.Abounts.Find(id);
        }
    }
}
