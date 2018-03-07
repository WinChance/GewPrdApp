using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrdDb.DAL
{
    [Table("User")]
    public partial class User
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Addr { get; set; }

        public int? Age { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birth { get; set; }

        [StringLength(2)]
        public string Sex { get; set; }
    }
}
