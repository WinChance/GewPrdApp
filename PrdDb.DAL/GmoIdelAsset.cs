using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrdDb.DAL
{
    public partial class GmoIdelAsset
    {
        public int Id { get; set; }
       	
        [Required]
        [StringLength(20)]
        public string DeptName { get; set; }

        [Required]
        [StringLength(20)]
        public string ZicanId { get; set; }

        [Required]
        [StringLength(100)]
        public string ZicanName { get; set; }

        [StringLength(50)]
        public string Pinpai { get; set; }

        [StringLength(50)]
        public string Xinghao { get; set; }

        [Required]
        [StringLength(50)]
        public string CunfangDidian { get; set; }

        [Column(TypeName = "date")]
        public DateTime QidongDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime BeginDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Reason { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        [StringLength(50)]
        public string Fuzeren { get; set; }

        public decimal? Yuanzhi { get; set; }

        public decimal? LeijiZhejiu { get; set; }

        public decimal? JingZhi { get; set; }

        //[Required]
        //[StringLength(10)]
        public string Inputer { get; set; }

        public DateTime? InputDatetime { get; set; }

        //[Required]
        //[StringLength(10)]
        public string Modifier { get; set; }

        public DateTime? ModifyDatetime { get; set; }
    }
}
