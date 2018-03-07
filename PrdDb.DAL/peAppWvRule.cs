namespace PrdDb.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("peAppWvRule")]
    public partial class peAppWvRule
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string code { get; set; }

        [Required]
        [StringLength(50)]
        public string itemname { get; set; }

        [StringLength(10)]
        public string value1 { get; set; }

        [StringLength(10)]
        public string value2 { get; set; }

        [StringLength(10)]
        public string type { get; set; }

        [StringLength(10)]
        public string WorkerType { get; set; }
    }
}
