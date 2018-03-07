namespace PrdAppDB_UAT.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int Iden { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public int Count { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        [StringLength(10)]
        public string Owner { get; set; }
    }
}
