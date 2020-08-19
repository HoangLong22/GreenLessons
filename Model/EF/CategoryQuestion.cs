using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("CategoryQuestion")]
    public partial class CategoryQuestion
    {    
        public long ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Loại câu hỏi")]
        public string Name { set; get; }
        public bool Status { get; set; }
    }
}
