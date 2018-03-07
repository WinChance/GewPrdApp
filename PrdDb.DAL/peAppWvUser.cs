using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrdDb.DAL
{
    [Table("peAppWvUser")]
    public partial class peAppWvUser
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string code { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        [Required]
        [StringLength(30)]
        public string password { get; set; }

        [Required]
        [StringLength(30)]
        public string dept { get; set; }

        [StringLength(8)]
        public string NfcCardNo { get; set; }

        [StringLength(10)]
        public string SubDept { get; set; }

        [StringLength(100)]
        public string ConnectionId { get; set; }


        public bool? IsLogin { get; set; }
    }
}
