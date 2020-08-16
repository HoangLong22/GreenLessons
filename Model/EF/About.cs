namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        public int ID { get; set; }

        [Display(Name = "Tên")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Meta Title")]
        [StringLength(50)]
        public string MetaTitle { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(50)]
        public string Description { get; set; }

        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }

        [Display(Name = "Nôi dung")]
        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        public string MetaKeywords { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
