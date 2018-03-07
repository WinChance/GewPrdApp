namespace PrdDb.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("peAppWvYieldCheck")]
    public partial class peAppWvYieldCheck
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime inputdate { get; set; }

        [StringLength(10)]
        public string inputclass { get; set; }

        [StringLength(10)]
        public string name1 { get; set; }

        [StringLength(10)]
        public string name2 { get; set; }

        [StringLength(10)]
        public string name3 { get; set; }

        [StringLength(10)]
        public string machineno { get; set; }

        [StringLength(20)]
        public string gfno { get; set; }

        [Required]
        [StringLength(30)]
        public string itemname { get; set; }

        public decimal value1 { get; set; }

        public decimal value2 { get; set; }

        [StringLength(10)]
        public string Audit { get; set; }

        [StringLength(250)]
        public string remark { get; set; }

        public DateTime input_time { get; set; }

        [StringLength(10)]
        public string WorkerType { get; set; }
    }
}
