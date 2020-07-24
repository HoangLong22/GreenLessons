using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Model.EF
{
    [Table("UserGroup")]
    public class UserGroup
    {
        [Key]
        [StringLength(20)]
        public string  ID { set; get; }

        [StringLength(50)]
        public string Name { set; get; }
    }
}
