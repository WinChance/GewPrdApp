namespace GewPeApp.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("peAppWvWorker")]
    public partial class peAppWvWorker
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string factory { get; set; }

        [Required]
        [StringLength(10)]
        public string name { get; set; }

        [Required]
        [StringLength(11)]
        public string cardno { get; set; }

        [Column("class")]
        [Required]
        [StringLength(10)]
        public string _class { get; set; }

        [StringLength(20)]
        public string classdes { get; set; }

        [StringLength(20)]
        public string jobs { get; set; }

        [StringLength(1)]
        public string Audit { get; set; }

        [StringLength(10)]
        public string WorkerType { get; set; }
    }
}
