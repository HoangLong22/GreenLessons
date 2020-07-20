namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypeMenu")]
    public partial class TypeMenu
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
