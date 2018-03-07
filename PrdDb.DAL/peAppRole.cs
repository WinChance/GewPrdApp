using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrdDb.DAL
{
    [Table("peAppRole")]
    public partial class peAppRole
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(300)]
        public string Info { get; set; }

        [StringLength(4000)]
        public string BusinessPermissionString { get; set; }
    }
}
