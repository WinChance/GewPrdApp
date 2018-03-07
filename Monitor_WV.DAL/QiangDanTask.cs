using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monitor_WV.DAL
{
    [Table("QiangDanTask")]
    public partial class QiangDanTask
    {
        public int Id { get; set; }

        public int? SLID { get; set; }

        [Required]
        [StringLength(20)]
        public string CardNo { get; set; }

        [Required]
        [StringLength(4)]
        public string MachineName { get; set; }

        [Required]
        [StringLength(5)]
        public string Department { get; set; }

        [StringLength(20)]
        public string WeaverNo1 { get; set; }

        [StringLength(10)]
        public string WeaverName1 { get; set; }

        [StringLength(20)]
        public string WeaverNo2 { get; set; }

        [StringLength(10)]
        public string WeaverName2 { get; set; }

        [StringLength(20)]
        public string WeaverNo3 { get; set; }

        [StringLength(10)]
        public string WeaverName3 { get; set; }

        [StringLength(5)]
        public string WeaverClass { get; set; }

        [StringLength(10)]
        public string WeaverGroup { get; set; }

        //public DateTime? ChangeTime { get; set; }

        public DateTime? HitTime { get; set; }

        public DateTime? BeginTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int TaskStatus { get; set; }

        public bool? AssignType { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(50)]
        public string FeedBack { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }
    }
}
