namespace GewPeApp.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("peAppWvYield")]
    public partial class peAppWvYield
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime inputdate { get; set; }

        [StringLength(10)]
        public string inputclass { get; set; }

        [StringLength(10)]
        public string name { get; set; }

        [StringLength(10)]
        public string machineno { get; set; }

        [StringLength(20)]
        public string gfno { get; set; }

        [Required]
        [StringLength(30)]
        public string itemname { get; set; }

        public decimal value1 { get; set; }

        public decimal value2 { get; set; }

        [Required]
        [StringLength(10)]
        public string Reviewer { get; set; }

        [StringLength(250)]
        public string remark { get; set; }

        public DateTime input_time { get; set; }

        [StringLength(10)]
        public string WorkerType { get; set; }
    }
}
