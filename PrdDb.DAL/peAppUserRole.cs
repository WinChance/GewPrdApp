using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrdDb.DAL
{
    [Table("peAppUserRole")]
    public partial class peAppUserRole
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int RoleID { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
