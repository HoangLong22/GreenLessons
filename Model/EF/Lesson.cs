namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lesson")]
    public partial class Lesson
    {
        public long ID { get; set; }

        [Display(Name = "Tên bài giảng")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(50)]
        public string Description { get; set; }

        [Display(Name = "Nội dung tiêu đề")]
        [StringLength(50)]
        public string MetaTitle { get; set; }

        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }

        [Display(Name = "Tên khoá học")]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Display(Name = "Tên danh mục")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [Display(Name = "Nội dung bài giảng")]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [Display(Name = "Nội dung Seo")]
        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Ngưới cập nhật")]
        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [Display(Name = "Người cập nhật")]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Display(Name = "Tìm kiếm")]
        public string MetaKeywords { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Display(Name = "Người khởi tạo")]
        [StringLength(50)]
        public string UserBy { get; set; }
    }
}
