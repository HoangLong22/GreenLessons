namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("New")]
    public partial class New
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên tin tức")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [StringLength(50)]
        [Display(Name = "Meta Title")]
        public string MetaTitle { get; set; }

        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }

        [Display(Name = "Người tạo")]
        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nôi dung")]
        public string Content { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên đăng nhập")]
        public string ModifiedBy { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public string MetaKeywords { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? Status { get; set; }

        [StringLength(50)]
        public string UserBy { get; set; }
    }
}
