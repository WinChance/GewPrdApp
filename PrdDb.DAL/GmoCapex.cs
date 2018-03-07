using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrdDb.DAL
{
    [Table("GmoCapex")]
    public partial class GmoCapex
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string AnnualBudgetId { get; set; }

        [Required]
        [StringLength(20)]
        public string DeptName { get; set; }

        [Required]
        [StringLength(20)]
        public string PrjLeader { get; set; }

        [Required]
        [StringLength(50)]
        public string PrjName { get; set; }

        public decimal YusuanMoney { get; set; }

        [Required]
        [StringLength(10)]
        public string BudgetQuarter { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [StringLength(100)]
        public string JinduMiaoshu { get; set; }

        public string CapexId { get; set; }

        public decimal ShenqingMoney { get; set; }

        //[Required]
        [StringLength(100)]
        public string HuiguJieguo { get; set; }

        [StringLength(20)]
        public string Inputer { get; set; }

        public DateTime? InputDatetime { get; set; }

        [StringLength(20)]
        public string Modifier { get; set; }

        public DateTime? ModifyDatetime { get; set; }
    }
}
