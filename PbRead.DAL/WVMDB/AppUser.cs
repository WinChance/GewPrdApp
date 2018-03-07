using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PbRead.DAL.WVMDB
{
    [Table("AppUser")]
    public partial class AppUser
    {
        [Key]
        [StringLength(20)]
        public string UserID { get; set; }

        [Required]
        [StringLength(30)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string UserCard { get; set; }

        [Required]
        [StringLength(1000)]
        public string Password { get; set; }

        [Required]
        [StringLength(10)]
        public string Department { get; set; }

        [Required]
        [StringLength(10)]
        public string Destination { get; set; }

        [Required]
        [StringLength(10)]
        public string Class_Type { get; set; }

        [StringLength(100)]
        public string Descript { get; set; }

        public bool? Is_Admin { get; set; }

        public bool? Is_Active { get; set; }
    }
}
