using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrdDb.DAL
{
    [Table("SsCheckYarn")]
    public partial class SsCheckYarn
    {
        public int Id { get; set; }

        public DateTime InputDate { get; set; }

        public int MachineNo { get; set; }

        [Required]
        [StringLength(10)]
        public string BatchNo { get; set; }

        public int CheckNum { get; set; }

        [StringLength(30)]
        public string OperateType { get; set; }

        public int SongjinNum { get; set; }

        public int DaxiaoDiffNum { get; set; }

        public int ChengxingBadNum { get; set; }

        [StringLength(5)]
        public string WorkerClass { get; set; }

        [Required]
        [StringLength(10)]
        public string CheckerName { get; set; }
    }
}
