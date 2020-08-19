using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("Question")]
    public partial class Question
    {
        public long ID { get; set; }

        [Display(Name = "Tên khoá học")]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Display(Name = "Loại câu hỏi")]
        [StringLength(50)]
        public string CategoryQuestion { get; set; }

        [Display(Name = "Bài số")]
        [StringLength(50)]
        public string Unit { get; set; }

        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }

        [Display(Name = "Nội dung câu hỏi")]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [Display(Name = "Đáp án A")]
        [Column(TypeName = "ntext")]
        public string Answer1 { get; set; }

        [Display(Name = "Đáp án B")]
        [Column(TypeName = "ntext")]
        public string Answer2 { get; set; }

        [Display(Name = "Đáp án C")]
        [Column(TypeName = "ntext")]
        public string Answer3 { get; set; }

        [Display(Name = "Đáp án D")]
        [Column(TypeName = "ntext")]
        public string Answer4 { get; set; }

        [Display(Name = "Đáp án đúng")]
        [Column(TypeName = "ntext")]
        public string CorrectAnswer { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }
    }
}
