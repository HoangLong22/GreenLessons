namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public long ID { get; set; }
        [Display(Name = "Tên danh mục")]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string MetaTitle { get; set; }

        public long? ParentID { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(50)]
        public string SeoTitle { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
        [Display(Name = "Người tạo")]
        [StringLength(50)]
        public string UserBy { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        public string MetaKeywords { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? Status { get; set; }
    }
}