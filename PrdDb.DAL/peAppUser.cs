using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrdDb.DAL
{
    [Table("peAppUser")]
    public partial class peAppUser
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string LoginName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsActive { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Dept { get; set; }
    }
}
