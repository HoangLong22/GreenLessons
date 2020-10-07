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
        
        public long ID { get; set; }

        [StringLength(50)]
        [Display(Name = "New_Name", ResourceType = typeof(StaticResource.Resources))]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Descriptions", ResourceType = typeof(StaticResource.Resources))]
        public string Description { get; set; }

        [StringLength(50)]
        [Display(Name = "Meta_Title", ResourceType = typeof(StaticResource.Resources))]
        public string MetaTitle { get; set; }

        [Display(Name = "Photo_Image", ResourceType = typeof(StaticResource.Resources))]
        public string Image { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Content_New", ResourceType = typeof(StaticResource.Resources))]
        public string Content { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        [Display(Name = "Day_Create", ResourceType = typeof(StaticResource.Resources))]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Sign_Name", ResourceType = typeof(StaticResource.Resources))]
        public string ModifiedBy { get; set; }

        [StringLength(50)]
        [Display(Name = "Create_By", ResourceType = typeof(StaticResource.Resources))]
        public string CreatedBy { get; set; }

        public string MetaKeywords { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Status", ResourceType = typeof(StaticResource.Resources))]
        public bool Status { get; set; }

        [StringLength(50)]
        [Display(Name = "User_Create", ResourceType = typeof(StaticResource.Resources))]
        public string UserBy { get; set; }

        public String Language { get; set; }
    }
}
